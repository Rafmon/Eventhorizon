# Event Horizon

**Event Horizon** is a sleek, modern application designed to simulate and manage time-based events, complete with GPIO support for Raspberry Pi devices. The application features a Blazor web interface with localization support, making it easy to switch between multiple languages. It can be run locally or deployed as a Docker container, and has options for running on various platforms including Windows, Linux, and ARM architectures.

## Features

- **Time-based Event Control**: Create, schedule, and manage events with customizable timelines.
- **GPIO Integration**: Control Raspberry Pi GPIO pins directly from the application.
- **Multi-language Support**: Easily switch between multiple languages using the built-in dropdown.
- **Real-time Control**: Adjust event timelines in real-time with play, pause, and speed controls.
- **Docker Compatibility**: Deployable via Docker, with support for ARM and multi-platform builds.
- **SQLite Database Integration**: Use a simple SQLite database for storing event configurations and states.


## Installation Guide

### Prerequisites

- Raspberry Pi 4 with Raspberry Pi OS installed
- Docker and Docker Compose installed on your Raspberry Pi

### Steps

1. **Clone the Repository**

    Open a terminal on your Raspberry Pi and run the following command to clone the repository:

    ```sh
    mkdir EventHorizon
    cd EventHorizon
    ```

2. **Download the Docker Compose File**

    Download the `docker-compose.deploy.yml` file:

    ```sh
    wget https://raw.githubusercontent.com/Rafmon/Eventhorizon/refs/heads/main/docker-compose.deploy.yml
    ```

3. **Run Docker Compose**

    Start the application using Docker Compose:

    ```sh
    sudo docker-compose -f docker-compose.deploy.yml up -d
    ```

4. **Access the Application**

    Open a web browser and navigate to `http://<your-raspberry-pi-ip>:<80>` to access the Event Horizon web interface.

### Default Configuration

The default configuration is set up for a Raspberry Pi 4 running Raspberry Pi OS. Adjustments may be needed for other setups.

For more detailed instructions and configuration options, refer to the official documentation.

The default port is 80 feel free to change this in the `docker-compose.deploy.yml`.



