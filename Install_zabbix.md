# Install Zabbix-server to monitor a network.

# Be a superuser

sudo -s 

# Install Mysql-server for database

apt install mysql-server -y

# Install Zabbix Repository

wget https://repo.zabbix.com/zabbix/7.4/release/ubuntu/pool/main/z/zabbix-release/zabbix-release_latest_7.4+ubuntu24.04_all.deb
dpkg -i zabbix-release_latest_7.4+ubuntu24.04_all.deb
apt update

# Install Zabbix server, frontend, agent

apt install zabbix-server-mysql zabbix-frontend-php zabbix-apache-conf zabbix-sql-scripts zabbix-agent

# Install Zabbix agent 2 plugins

apt install zabbix-agent2-plugin-mongodb zabbix-agent2-plugin-mssql zabbix-agent2-plugin-postgresq l 

# Create initial database

mysql -uroot -p
password
mysql> create database zabbix character set utf8mb4 collate utf8mb4_bin;
mysql> create user zabbix@localhost identified by 'password';
mysql> grant all privileges on zabbix.* to zabbix@localhost;
mysql> set global log_bin_trust_function_creators = 1;
mysql> quit;

# On Zabbix server host import initial schema and data. You will be prompted to enter your newly created password.

zcat /usr/share/zabbix/sql-scripts/mysql/server.sql.gz | mysql --default-character-set=utf8mb4 -uzabbix -p zabbix 

# Disable log_bin_trust_function_creators option after importing database schema. 

mysql -uroot -p
password
mysql> set global log_bin_trust_function_creators = 0;
mysql> quit;

# Configure the database for Zabbix server

# Edit file /etc/zabbix/zabbix_server.conf

sudo nano /etc/zabbix/zabbix_server.conf

DBPassword=password

# Start Zabbix server and agent processes 

systemctl restart zabbix-server zabbix-agent2 apache2
systemctl enable zabbix-server zabbix-agent2 apache2 

# Open Zabbix UI web page 

The default URL for Zabbix UI when using Apache web server is http://host/zabbix 

# now, either you can log-in at http://localhost/zabbix
# Or instead of the localhost just type in the ip address of the server. 

################################################################################


