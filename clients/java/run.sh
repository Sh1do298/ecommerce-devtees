#!/bin/bash
# Script para compilar e executar o JavaClient

set -e  # para parar se der erro

# Ir para a pasta do script
cd "$(dirname "$0")"

# Compilar
echo "Compilando JavaClient.java..."
javac JavaClient.java

# Executar
echo "Executando JavaClient..."
java JavaClient
