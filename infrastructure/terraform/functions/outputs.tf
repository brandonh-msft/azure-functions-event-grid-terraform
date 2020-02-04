output "functionapp_endpoint_base" {
  value = azurerm_function_app.fxn.default_hostname
}

output "function_app_name" {
  value = azurerm_function_app.fxn.name
}

output "tenant_id" {
  value = azurerm_function_app.fxn.identity[0].tenant_id
}

output "principal_id" {
  value = azurerm_function_app.fxn.identity[0].principal_id
}