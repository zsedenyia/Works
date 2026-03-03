#  az login --tenant 1359854f-2e91-42f1-800f-38df9a47df38


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