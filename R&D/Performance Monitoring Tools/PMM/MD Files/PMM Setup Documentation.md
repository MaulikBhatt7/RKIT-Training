# PMM Server and Client Setup Documentation

## Prerequisites

- Docker Desktop installed on Windows
- Ubuntu 20.04 system for PMM Client

## Step 1: Set up PMM Server using Docker Desktop UI

1. Open Docker Desktop on your Windows machine.
2. Ensure you are using Linux containers.
3. Pull the PMM Server image version 2.41.2:

    ```sh
    docker pull percona/pmm-server:2.41.2
    ```

4. Open the Docker Desktop UI and create a new container:
   - Click on "Containers/Apps" in the left sidebar.
   - Click on the "Run" button to create a new container.
   - In the "Image" field, enter `percona/pmm-server:2.41.2`.
   - In the "Container Name" field, enter `PMM-Server`.
   - Under "Optional Settings," specify the ports:
     - Enter `0` to assign randomly generated host ports.

5. Click on the "Run" button to start the container.
6. Note the randomly assigned host ports for HTTP and HTTPS. For example, if the ports are assigned as `55000` for HTTP and `55001` for HTTPS, use these ports in the next steps.

## Step 2: Set up PMM Client on Ubuntu

1. On your Ubuntu machine, download the PMM Client package using `wget`:

    ```sh
    wget https://downloads.percona.com/downloads/pmm2/2.41.2/binary/debian/focal/x86_64/pmm2-client_2.41.2-6.focal_amd64.deb?_gl=1*1gyi662*_gcl_au*MjY1MzA3MzkwLjE3Mzk1MDkzNDc.
    ```

2. Install the PMM Client package using `dpkg`:

    ```sh
    sudo dpkg -i pmm2-client_2.41.2-6.focal_amd64.deb
    ```

3. Verify the PMM Client installation by checking the version:

    ```sh
    pmm-admin --version
    ```

4. The output should display the PMM Client version 2.41.2, confirming the installation was successful.

    ```
    ProjectName: pmm-admin
    Version: 2.41.2
    PMMVersion: 2.41.2
    ```

## Conclusion

You have successfully set up the PMM Server using Docker Desktop UI and the PMM Client on an Ubuntu system.