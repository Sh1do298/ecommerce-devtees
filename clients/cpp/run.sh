#!/bin/bash
# Script para compilar e executar o cliente C++

set -e
cd "$(dirname "$0")"

# Dependência necessária: libcurl
if ! dpkg -s libcurl4-openssl-dev &> /dev/null; then
  echo "⚠️ Instalando libcurl..."
  sudo apt-get update && sudo apt-get install -y libcurl4-openssl-dev
fi

echo "🛠️ Compilando cpp_client.cpp..."
g++ cpp_client.cpp -o cpp_client -lcurl

echo "🚀 Executando cliente C++..."
./cpp_client
