# Switch from User Exec mode to privilege exec modle

enable

# Configure Terminal - Make changes

Configure terminal    or config t

# Change router or switch name

hostname R1 or SW1

# Secure priviledge exec mode 

enable secret password - type 7 encryption - can looked up on the net

# Secure all passwords in the config file 

service password-encryption

# enable secret - md5 encryption - more secure

enable secret "password"

# secure user exec mode 

line console 0
password "password"
login

# Banner for the message of the day

banner motd #No Authorized access allowed!#

# Set domain name 
ip domain-name cisco.com

# generate 1024 bit rsa key pair

crypto key generate rsa

# Create a local user "admin" with the password "ccna".  Set all vty lines to use ssh and local login for remote connections. Exit out to global configuration mode.

Username admin password ccna
line vty 0 15
transport input ssh
login local
exit

# Configure SSH 2.0 - more secure

ip ssh version 2

# to check ssh connection to the device 

show ssh

# Login to switch or router via ssh

SSH -l "username" "ip address"

# secure remote telnet / SSH access

line vty 0 4
password password
login
transport input {ssh | telnet | none | all}

# Configure interface ex. vlan 1

Interface vlan 1
ip address 192.168.1.1 255.255.255.0
no shutdown
exit
ip default-gateway 192.168.1.1

# To save settings - Because it does not automatically

copy running-config startup-config

# or

write

# To see IP interface 

show ip inteface brief



