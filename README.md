# WorkoutTracking

WorkoutTracking is an application designed for logging workouts in the gym. It consists of a microservice architecture with a Vue.js frontend, a .NET API Gateway using YARP, services implemented in .NET with FastEndpoints, and PostgreSQL databases.

## Features

- **Logging Workouts**: Record your gym sessions including exercises, sets, reps, and weights.
- **Microservice Architecture**: Utilizes Vue.js for frontend, .NET with YARP for API Gateway, and .NET with FastEndpoints for backend services.
- **Database**: PostgreSQL is used as the primary database for storing workout logs.
- **Docker Compose**: Example Docker Compose configuration provided (`docker-compose.example.yml`) for local development. Requires adding necessary secrets.
- **Kubernetes Deployment**: Production and staging Kubernetes configurations are available under `Kubernetes/Production` and `Kubernetes/Staging` respectively.
  - **Production**: Deployed on Azure Kubernetes Service (AKS).
  - **Staging**: Deployed on Fontys School Netlab Kubernetes cluster.
- **Secrets Management**: Secrets examples are provided in the `Kubernetes/Secrets` folder. These need to be configured with appropriate credentials and keys for deployment.

## Requirements

- Docker

## Installation and Setup

### Local Development with Docker Compose

1. Clone the repository:

   ```bash
   git clone https://github.com/CarloKessel/WorkoutTracking.git
   cd WorkoutTracking
2. Navigate to the `docker-compose.example.yml` file and add your secrets. 
3. docker-compose -f docker-compose.example.yml up
4. Access the frontend at `http://127.0.0.1:8080`.
