# Installed Softwares

# Latest Ubuntu Linux - 24.04

################################

# Install Clam-AV - Ubuntu free Antivirus ->

# Upate and Upgrade the Ubuntu system to its latest
sudo apt update && sudo apt upgrade -y

# Install Clam-AV
sudo apt install clamav clamav-daemon -y

# Update clam-AV

sudo systemctl stop clamav-freshclam
sudo freshclam
sudo systemctl start clamav-freshclam

# search for viruses

clamscan -r --bell ~/

####################################

# Install G-Parted -> This is similar to disk manager on windows

sudo apt install gparted

####################################

# Install Apache HTTP Server on Ubuntu

sudo apt update
sudo apt install apache2 -y
sudo service apache2 stop																											
sudo service apache2 start		
sudo service apache2 restart

####################################

Install PHP 7.4 - Owncloud 10.15 works only PHP 7.4

sudo apt install software-properties-common -y
sudo add-apt-repository ppa:ondrej/php -y
sudo apt update
sudo apt install php7.4 php7.4-{opcache,gd,curl,mysqlnd,intl,json,ldap,mbstring,imagick,cli,bcmath,mysql,xml,zip} -y

php -v   -> control if php installed correctly

#####################################

# Install MariaDB Database Server

sudo apt install mariadb-server -y

sudo service mysql stop
sudo service mysql start
sudo service mysql restart

sudo mysql_secure_installation

## Enter current password for root: press enter (We have no password)

## Setup new password: Y -> yes
## Enter Database Root password: "Your Password"

## Disallow root login remotely: -> press Y
   
## Remove test database and access to it: press Y

## Reload privilege tables now: press Y

   
## remove Anonymous users: press Y
   
## Now create a new database with the code below:

sudo mysql -u root -p

CREATE DATABASE owncloud;
CREATE USER 'Username'@'localhost' IDENTIFIED BY 'Your_password ';
GRANT ALL PRIVILEGES ON owncloud.* TO 'Username'@'localhost' WITH GRANT OPTION;
FLUSH PRIVILEGES;
EXIT;

#######################################

# Download owncloud

# Download unzip

sudo apt install unzip      

# Download Latest owncloud Version

wget https://download.owncloud.com/server/stable/owncloud-latest.zip -P /tmp

# unpack it to the var/www folder ##   

sudo unzip /tmp/owncloud-latest.zip  -d /var/www

# Set permission

sudo chown -R www-data:www-data /var/www/owncloud/
sudo chmod -R 755 /var/www/owncloud/

#########################################

# Configure owncloud Site

# Open Owncloud Configuration File

sudo nano /etc/apache2/sites-available/owncloud.conf

## Copy All These Below ##


<Virtualhost *:80>
        ServerAdmin admin@example.com
        DocumentRoot /var/www/owncloud/
        Servername localhost
        ServerAlias 127.0.0.1


        Alias /owncloud "/var/www/owncloud/"


        <Directory /var/www/owncloud/>
        Options +FollowSymlinks
        AllowOverride All
        Require all granted
            <IfModule mod_dav.c>
            Dav off
            </IfModule>
        SetEnv Home /var/www/owncloud
        SetEnv HTTP_Home /var/www/owncloud
        </Directory>
    
        ErrorLog ${APACHE_LOG_DIR}/error.log
        Customlog ${APACHE_LOG_DIR}/access.log combined

</VirtualHost>


CTRL + X  and YES = save


# Run the following commands all at once:

sudo a2ensite owncloud.conf
sudo a2enmod rewrite
sudo a2enmod headers
sudo a2enmod env
sudo a2enmod dir
sudo a2enmod mime


# Restart apache server

sudo systemctl restart apache2

#################################################

# Check if the website is working

## Open a browser and write in your ubuntu ip address or localhost

   
## Create a new admin account at the login page but do not log-in yet!!!

    User: "your admin username"
    Pass: "Your password"

## Click on configure database MySQL/MariaDB

    Database User:  "Your database username"
    Database Pass:  "Your database password"
    Database Name:  owncloud
    Database Host:  localhost


## Click on Finish Setup -> Now you can Log-In.

#################################################

# Port forwarding - make sure you have static Ip for your computer.
# Forward port 80 on your router to your Ubuntu Computer where owncloud is installed.

#################################################

##  Owncloud configuration file

sudo nano /etc/apache2/sites-available/owncloud.conf

## CTRL + X and Y to save

## Restart apache to apply changes

sudo service apache2 restart

## Now apache pointing to the public address but it is not yet configured to owncloud! ##

sudo nano /var/www/owncloud/config/config.php

## Search for trusted domains, under array 0-> pointing the computer Private LAN IP
## Create: 1-> 'your_public_ip',


# Restart apache to apply changes
    
sudo service apache2 restart

##################################################

# If you use Dynamic DNS then NO-IP is a good choice. You can use up to 3 domain for free.

# To install NO-IP Dynamic DNS checker on Ubuntu

# Install No-IP Duc

 # Our Dynamic Update Client runs on your computer and checks frequently for an IP address change. When a different IP address is detected, the DUC automatically updates your hostname to the correct IP address.

# Download and install the linux DUC in terminal
        
wget --content-disposition https://www.noip.com/download/linux/latest

# Unpack the tar file
tar xf noip-duc_3.3.0.tar.gz

# Go to folder and Install        
cd /home/$USER/noip-duc_3.3.0/binaries && sudo apt install ./noip-duc_3.3.0_amd64.deb

# Once installed, run noip-duc to start the program. You will want to explore the various options, so run noip-duc --help to see the available commands.

# To login and send updates using DDNS Keys enter the following 

noip-duc -g all.ddnskey.com --username <DDNS Key Username> --password <DDNS Key Password>

####################################################

# Install https certificate - Let's Ecrypt

# 1. Install Certificate

sudo apt install certbot python3-certbot-apache -y

# 2.  Give certificate to your dns Address

sudo certbot --apache -d yourdomain.com -d www.yourdomain.com

# 3. Redirect HTTP to HTTPS (Optional but Recommended)

sudo nano /etc/apache2/sites-available/000-default.conf

# Add this inside the  block:

Redirect permanent / https://yourdomain.com/

# Then restart Apache:

sudo systemctl restart apache2

# Check Auto-Renewal
# Certbot sets up a cron job. You can test it manually:

sudo certbot renew --dry-run

# Now your domain is in HTTPS secure site.
####################################################

# if you want the HTTP server to boot with system startup

sudo systemctl enable apache2

###################################################

# you can do a safety backup to an internal or external HDD with timeshift. To be able to do that you have to add a new HDD to the system.

# How to add HDD to Ubuntu.

# Check Which hard drives connected to the computer. Check UUID.

lsblk

# Create a folder where you want to mount the hdd.

sudo mkdir /media/user/hdd

# Mount the drive to the folder
# Check dev/sdb1 -> which hdd want to mount. Also check folder where you want to mount

sudo mount /dev/sdb1 /media/user/hdd

# Check if it is mounted

df -h

# Make it permanent mounting at boot

# Check UUID

sudo blkid

# Open Fstab editor

sudo nano /etc/fstab

Add your hdd line here
# Check UUID and check mounting folder

UUID=your-uuid-here /mnt/mydrive ext4 defaults 0 2

# Permission - If you want a non-root user to access the drive:
# Check Mounting folder

sudo chown yourusername:yourusername /mnt/mydrive

###############################################################

# Install Timeshift - A backup software

# Timeshift works like Apple Timemachine 
# It does an original backup first, which is takes a little bit of time, depends how much data you need to backup.
# Then It does a monthly, weekly and a daily backup.

# To install

sudo apt install timeshift

# If you want the absolut latest Timeshift

# Add Timeshift PPA:

sudo add-apt-repository ppa:teejee2008/timeshift

# Do an Update

sudo apt update

# Install TimeShift

sudo apt install timeshift

################################################################



