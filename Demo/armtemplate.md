# Login to Azure
az login

# Create a resource group
az group create --name ArmDemoRG --location NorthEurope

# Deploy the ARM template
az deployment group create --resource-group ArmDemoRG --template-file vm_arm_template.json
