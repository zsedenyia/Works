terraform {
  required_providers {
    aazurerm = {
      source  = "Azure/azurerm"
      version = "~> 4.8.0"
    }
  }
  required_version = ">=1.9.0"
}
provider "azurerm" {
  features {}
}