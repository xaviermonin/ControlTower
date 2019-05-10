using System;
using System.Collections.Generic;
using System.Text;

namespace InternetCommands
{
    public class ByteStream : System.IO.Stream 
    {
        private const int preBuffering = 65535;

        private byte[] buffer;
        private long length;
        private long offset;

        private Stack<long> offsetStack;

        #region constructeurs
        /// <summary>
        /// Construit un ByteStream avec un buffer par défaut
        /// </summary>
        public ByteStream() {
            offsetStack = new Stack<long>();
            offset = 0;
            length = 0;
            buffer = new byte[preBuffering];
        }

        /// <summary>
        /// construit un bytestream à partir du buffer passé en paramètre
        /// </summary>
        /// <param name="Source"></param>
        public ByteStream(byte[] Source) {
            offsetStack = new Stack<long>();
            buffer = Source;
            length = Source.Length;
        }
        #endregion

        #region Empilement des offset
        public void Push() {
            offsetStack.Push(offset);
        }

        public void Push(long Position) {
            offsetStack.Push(offset);
            this.Position = Position;
        }

        public void Pop() {
            //if (offsetStack.Count > 0)
                offset = offsetStack.Pop();
        }

        public void PopAll() {
            while (offsetStack.Count>0)
                offset = offsetStack.Pop();
        }
        #endregion

        #region capacités
        /// <summary>
        /// indique si le buffer peut être lu
        /// </summary>
        public override bool CanRead {
            get { return true; }
        }

        /// <summary>
        /// indique si le buffer peut-être déplacé
        /// </summary>
        public override bool CanSeek {
            get { return true; }
        }

        /// <summary>
        /// indique si le buffer peut-être écrit
        /// </summary>
        public override bool CanWrite {
            get { return true; }
        }

        /// <summary>
        /// envoie les données sur le buffer (sans effet)
        /// </summary>
        public override void Flush() {
            ;
        }

        /// <summary>
        /// Longueur du buffer géré
        /// </summary>
        public override long Length {
            get { return length; }
        }
        #endregion

        #region manipulations
        /// <summary>
        /// Renvoie ou positionne le curseur de lecture
        /// </summary>
        public override long Position {
            get {
                return offset;
            }
            set {
                if (value < length) {
                    offset = value;
                } else {
                    offset = length;
                }
            }
        }

        /// <summary>
        /// Lit une série d'octet sur le buffer
        /// </summary>
        /// <param name="buffer">buffer cible de la lecture</param>
        /// <param name="offset">position d'écriture sur la cible</param>
        /// <param name="count">nombre d'octets à lire</param>
        /// <returns>nombre d'octets lus</returns>
        public override int Read(byte[] buffer, int offset, int count) {
            long icount = count;
            this.offset += offset;
            if (this.offset + icount > this.length) icount = this.length - this.offset;
            Array.Copy(this.buffer,this.offset,buffer, offset, count);
            return (int)icount;
        }

        /// <summary>
        /// Positionne le curseur de lecture
        /// </summary>
        /// <param name="offset">Décallage</param>
        /// <param name="origin">Origine</param>
        /// <returns>Position effective</returns>
        public override long Seek(long offset, System.IO.SeekOrigin origin) {
            switch (origin) {
            case System.IO.SeekOrigin.Current:
                Position = this.offset + offset;
                break;
            case System.IO.SeekOrigin.End:
                Position = length + offset;
                break;
            default:
            case System.IO.SeekOrigin.Begin:
                Position = offset;
                break;
            }
            return this.offset;
        }

        public override void SetLength(long value) {
            byte[] newbuffer = new byte[value];
            Array.Copy(buffer, newbuffer, length > value ? value : length);
        }

        public override void Write(byte[] buffer, int offset, int count) {
            EnsureLength(count);
            Array.Copy(buffer, offset, this.buffer, this.offset, count);
            this.offset += count;
        }

        public bool AtEndOfStream() {
            return (offset == length);
        }
        #endregion

        #region procédures d'écritures
        private void EnsureLength(long length) {
            if (this.offset + length > this.length) {
                SetLength(this.offset + length + preBuffering);
            }
        }

        /// <summary>
        /// Ecrit un entier sur le flux
        /// </summary>
        /// <param name="target">cible de l'écriture</param>
        /// <param name="offset">décallage</param>
        /// <param name="Value">valeur à écrire</param>
        public void Write(uint Value) {
            EnsureLength(4);
            buffer[offset] = (byte)(((int)Value >> 24) & 0xFF);
            buffer[offset + 1] = (byte)(((int)Value >> 16) & 0xFF);
            buffer[offset + 2] = (byte)(((int)Value >> 8) & 0xFF);
            buffer[offset + 3] = (byte)((int)Value & 0xFF);
            offset += 4;
            if (offset > length) length = offset;
        }

        /// <summary>
        /// Ecrit un entier court sur le flux
        /// </summary>
        /// <param name="target">cible de l'écriture</param>
        /// <param name="offset">décallage</param>
        /// <param name="Value">valeur à écrire</param>
        public void Write(ushort Value) {
            EnsureLength(2);
            buffer[offset] = (byte)(((int)Value >> 8) & 0xFF);
            buffer[offset + 1] = (byte)((int)Value & 0xFF);
            offset += 2;
            if (offset > length) length = offset;
        }

        /// <summary>
        /// Ecrit un octets sur le flux
        /// </summary>
        /// <param name="target">cible de l'écriture</param>
        /// <param name="offset">décallage</param>
        /// <param name="Value">valeur à écrire</param>
        public void Write(byte Value) {
            EnsureLength(1);
            buffer[offset] = Value;
            offset += 1;
            if (offset > length) length = offset;
        }

        /// <summary>
        /// Ecrit une chaine de caractères sur le flux
        /// </summary>
        /// <param name="target">cible de l'écriture</param>
        /// <param name="offset">décallage</param>
        /// <param name="Value">valeur à écrire</param>
        public void Write(string Value) {
            EnsureLength(Value.Length);
            System.Text.ASCIIEncoding.ASCII.GetBytes(Value, 0, Value.Length, buffer, (int)offset);
            offset += Value.Length;
            if (offset > length) length = offset;
        }

        /// <summary>
        /// Ecrit une chaine d'octets sur le flux
        /// </summary>
        /// <param name="target">cible de l'écriture</param>
        /// <param name="offset">décallage</param>
        /// <param name="Value">valeur à écrire</param>
        public void Write(byte[] Value) {
            EnsureLength(Value.Length);
            Array.Copy(Value, 0, buffer, offset, Value.Length);
            offset += Value.Length;
            if (offset > length) length = offset;
        }

        #endregion

        #region Procédures de lecture
        /// <summary>
        /// Lit un octet dans le flux courant
        /// </summary>
        /// <returns>Valeur lue</returns>
        public byte Read() {
            if (offset + 1 > length) throw new System.IO.EndOfStreamException();
            byte ret = buffer[offset];
            offset += 1;
            return (byte)ret;
        }


        /// <summary>
        /// Lit un octet dans le flux courant
        /// </summary>
        /// <returns>Valeur lue</returns>
        public override int ReadByte() {
            return (int)Read();
        }

        /// <summary>
        /// Lit un entier court dans le flux courant
        /// </summary>
        /// <returns>Valeur lue</returns>
        public ushort ReadShort() {
            if (offset + 2 > this.length) throw new System.IO.EndOfStreamException();
            int ret =
                ((int)buffer[offset] << 8) +
                (int)(buffer[offset + 1]);
            offset += 2;
            return (ushort)ret;
        }

        /// <summary>
        /// Lit un entier dans le flux courant
        /// </summary>
        /// <returns>Valeur lue</returns>
        public uint ReadInt() {
            if (offset + 4 > this.length) throw new System.IO.EndOfStreamException();
            uint ret =
                ((uint)buffer[offset] << 24) +
                ((uint)buffer[offset + 1] << 16) +
                ((uint)buffer[offset + 2] << 8) +
                ((uint)buffer[offset + 3]);
            offset += 4;
            return ret;
        }

        /// <summary>
        /// Lit une chaine en précisant sa taille dans le flux courant
        /// </summary>
        /// <param name="length">taille de la chaine à lire</param>
        /// <returns>Valeur lue</returns>
        public string ReadString(int length) {
            if (offset + length > this.length) throw new System.IO.EndOfStreamException();
            string ret = System.Text.ASCIIEncoding.ASCII.GetString(buffer, (int)offset, length);
            offset += length;
            return ret;
        }

        /// <summary>
        /// Lit une chaine en assumant qu'elle est précédée par sa taille dans le flux courant
        /// </summary>
        /// <returns>Valeur lue</returns>
        public string ReadString() {
            int length = ReadShort();
            return ReadString(length);
        }

        /// <summary>
        /// Lit un ensemble d'octets dans le tableau courant
        /// </summary>
        /// <param name="length">Longueur à lire</param>
        /// <returns>Copie des octets lus</returns>
        public byte[] ReadBytes(int length) {
            if (offset + length > this.length) throw new System.IO.EndOfStreamException();
            byte[] ret = new byte[length];
            Array.Copy(buffer, offset, ret, 0, length);
            offset += length;
            return ret;
        }

        /// <summary>
        /// Lit un ensemble d'octets dans le tableau courant
        /// </summary>
        /// <param name="length">Longueur à lire</param>
        /// <returns>Copie des octets lus</returns>
        public byte[] ToBytes() {
            byte[] ret = new byte[length];
            Array.Copy(buffer, ret, length);
            return ret;
        }

        #endregion
    }
}
