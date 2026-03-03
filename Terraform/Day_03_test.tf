#  az login --tenant 1359854f-2e91-42f1-800f-38df9a47df38

# Create a service principle with the following command and use the output to fill in the values below:
#  MSYS_NO_PATHCONV=1 az ad sp create-for-rbac -n az-demo --role Contributor --scopes /subscriptions/0c7b76e5-0b4f-4730-8f85-fb86f79473fc

# Force create bashhrc file with the following command to avoid path conversion issues on Windows when using Terraform:
# echo -e "export MSYS_NO_PATHCONV=1\nalias tf='terraform'" > ~/.bashrc

# Tell Git Bash to use the bashrc file with the following command:
# echo "[[ -f ~/.bashrc ]] && . ~/.bashrc" > ~/.bash_profile

# Apply and test
# source ~/.bashrc


terraform {
  required_providers {
    azurerm = {
      source  = "Hashicorp/azurerm"
      version = "~> 4.8.0"
    }
  }
  required_version = ">=1.9.0"
}
provider "azurerm" {
  features {

  }
}

