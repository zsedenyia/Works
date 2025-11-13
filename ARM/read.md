# This is a demo template to use Arm/json code to create a vm with all extra resources.

# Login to Azure
az login

# Create a resource group
az group create --name ArmDemoRG --location NorthEurope

# Deploy the ARM template
az deployment group create --resource-group ArmDemoRG --template-file demo.json

# to run all resources use the following command:

$ az deployment group create --resource-group ArmDemoRG --template-file demo.json