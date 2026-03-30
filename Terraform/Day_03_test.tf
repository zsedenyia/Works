#  az login --tenant <TENANT_ID>

# Create a service principle with the following command and use the output to fill in the values below:
#  MSYS_NO_PATHCONV=1 az ad sp create-for-rbac -n az-demo --role Contributor --scopes /subscriptions/<SUBSCRIPTION_ID>

# Force create bashhrc file with the following command to avoid path conversion issues on Windows when using Terraform:
# echo -e "export MSYS_NO_PATHCONV=1\nalias tf='terraform'" > ~/.bashrc

# Tell Git Bash to use the bashrc file with the following command:
# echo "[[ -f ~/.bashrc ]] && . ~/.bashrc" > ~/.bash_profile

# Apply and test
# source ~/.bashrc

# to initialize the infrastructure
# tf init

# To see the changes to the infrastucture
# tf plan

# To Validate the infrastructure, run the command
# tf validate

# with this command will be shown 'what will be created'
# tf plan | grep "will be created"

# to create infrastructure from code
# tf apply

# to update infrastructure, like change something
# tf plan -> tf apply --auto-approve

# to destroy the entire Infrastructure in Azure
# tf destroy --auto-approve

terraform {
  required_providers {
    azurerm = {
      source  = "hashicorp/azurerm"
      version = "~> 4.8.0"
    }
  }
  required_version = ">=1.14.6"
}
provider "azurerm" {
  features {}
  subscription_id = "<SUBSCRIPTION_ID>"
}

# Fixed: Changed azurearm to azurerm
resource "azurerm_resource_group" "example" {
  name     = "terraform-resources"
  location = "Sweden Central" # Note: Azure usually expects "Sweden Central" (with space)
}

resource "azurerm_storage_account" "example" {
  name                     = "terraformtest101"
  # Fixed: Reference now matches the corrected resource type above
  resource_group_name      = azurerm_resource_group.example.name
  location                 = azurerm_resource_group.example.location
  account_tier             = "Standard"
  account_replication_type = "LRS"

  tags = {
    environment = "staging"
  }
}
