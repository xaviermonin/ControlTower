# ControlTower

This project provides some hack tools for local network:

- Hosts scan

  Scan hosts by using arp. Provides optionnal name resolution.
- Man in the middle

  Intercept traffic between 2 hosts.
- ARP Poisoning

  Modify ARP table of the target.
- Router

- DNS Poisoning

  Modify DNS target. Must be used with MITM.
- Arp communicator

  Sending messages stealthily between 2 hosts using ARP.

# Prerequisites
Control Tower need NPCap or WinPCap and must be started with privilege elevation (UAC).

## Screenshots

### Host scan

![Scan Host](https://user-images.githubusercontent.com/5740369/98854506-ebffd280-245a-11eb-87ac-20989cfb2bda.png)

### ARP Poisoning

![ARP Poisoning](https://user-images.githubusercontent.com/5740369/98854503-eb673c00-245a-11eb-9af0-19f86c064823.png)

### Router

![Router](https://user-images.githubusercontent.com/5740369/98854505-ebffd280-245a-11eb-8019-87b063e6bb8f.png)

### DNS Poisoning

![DNS Poisoning](https://user-images.githubusercontent.com/5740369/98854504-eb673c00-245a-11eb-827e-0228ca8e3b58.png)
