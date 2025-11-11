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







