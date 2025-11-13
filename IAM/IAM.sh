# Add a new user to Azure AD

az ad user create --display-name myuser --password password --user-principal-name myuser@contoso.com

# Create a Resource Group

az group create --name MyResourceGroup --location NorthEurope

# Create a Blob Storage Account
az storage account create --name mystorageaccount --resource-group MyResourceGroup --location NorthEurope --sku Standard_LRS
# Create a Container in the Storage Account
az storage container create --name mycontainer --account-name mystorageacount  --public-access off  
# Upload a file to the Container
az storage blob upload --container-name mycontainer --file ./myfile.txt --name myfile.txt --account-name mystorageaccount
# List Blobs in the Container
az storage blob list --container-name mycontainer --account-name mystorageaccount --output table
# Download a Blob from the Container
az storage blob download --container-name mycontainer --name myfile.txt --file ./downloaded_myfile.txt --account-name mystorageaccount
# Delete a Blob from the Container
az storage blob delete --container-name mycontainer --name myfile.txt --account-name mystorageaccount
# Delete the Container
az storage container delete --name mycontainer --account-name mystorageaccount
# Delete the Storage Account
az storage account delete --name mystorageaccount --resource-group MyResourceGroup --yes
# Delete the Resource Group
az group delete --name MyResourceGroup --yes --no-wait
