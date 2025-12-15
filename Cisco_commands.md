# Switch from User Exec mode to privilege exec modle

enable

# Configure Terminal - Make changes

Configure terminal    or config t

# Change router or switch name

hostname "hostname"

# secure user exec mode 

line console 0
password "password"
login


# Secure priviledge exec mode 

enable secret password

# secure remote telnet / SSH access

line vty 0 4
password password
login
transport input {ssh | telnet | none | all}

# Secure all passwords in the config file 

service password-encryption

# provide legal notification

banner delimiter message delimiter

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



