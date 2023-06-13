#!/bin/bash

# Étapes de déploiement

# Étape 1 : Construire les images Docker
docker-compose build

# Étape 2 : Démarrer les conteneurs Docker
docker-compose up -d

# Étape 3 : Attendre un certain temps pour que les conteneurs démarrent complètement
sleep 10

# Étape 4 : Effectuer les migrations
# docker exec ressources_relationnelles-api-1 dotnet ef migrations add init --project <chemin_vers_votre_projet_api>
# docker exec ressources_relationnelles-api-1 dotnet ef database update --project <chemin_vers_votre_projet_api>

# docker run --rm -v <chemin_vers_votre_projet>:/app -w /app mcr.microsoft.com/dotnet/sdk:6.0 dotnet ef migrations add <nom_migration>
docker run --rm -v $(pwd)/ApiCube/ApiCube:/app -w /app mcr.microsoft.com/dotnet/sdk:6.0 dotnet ef migrations add init
docker run --rm -v "$(pwd)/ApiCube/ApiCube:/app" -w /app mcr.microsoft.com/dotnet/sdk:6.0 dotnet ef migrations add init
docker run --rm -v "$(pwd)/ApiCube/ApiCube:/app" -w /app mcr.microsoft.com/dotnet/sdk:6.0 dotnet ef migrations add init --project /app/ApiCube/ApiCube/ApiCube.csproj
docker run --rm -v "$(pwd)/ApiCube/ApiCube:/app" -w /app mcr.microsoft.com/dotnet/sdk:6.0 dotnet ef migrations add init --project-dir /app/ApiCube/ApiCube


# docker run --rm -v <chemin_vers_votre_projet>:/app -w /app mcr.microsoft.com/dotnet/sdk:6.0 dotnet ef database update
docker run --rm -v $(pwd)/ApiCube/ApiCube:/app -w /app mcr.microsoft.com/dotnet/sdk:6.0 dotnet ef database update

# Étape 5 : Autres tâches de déploiement (le cas échéant)

# Fin du script

