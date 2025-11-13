#!/bin/bash
az group create --name demo04 --location NorthEurope
az vm create --resource-group demo04 \
	--name DemoVM \
	--image Ubuntu2204 \
	--admin-username azureuser \
	--generate-ssh-keys \
	--size Standard_b1s \
	--custom-data @cloud-init.sh
#open port 80    
az vm open-port --resource-group demo04 --name DemoVM --port 80


# Got to the folder Demo and run the script Provision.sh

./provision.sh 

# this installs ubuntu with all the settings from all the other scripts




