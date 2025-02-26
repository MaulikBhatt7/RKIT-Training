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

## Step 3: Open Required Ports on Windows Defender Firewall

Before connecting the PMM Client to the PMM Server, ensure that the necessary ports are open on your Windows machine using Windows Defender Firewall.

1. Open the Windows Defender Firewall settings:
   - Click the Start button and type "Windows Defender Firewall".
   - Select "Windows Defender Firewall with Advanced Security".

2. Create a new inbound rule:
   - In the left sidebar, click "Inbound Rules".
   - In the right sidebar, click "New Rule".

3. Select the rule type:
   - Choose "Port" and click "Next".

4. Specify the ports:
   - Select "TCP".
   - In the "Specific local ports" field, enter the ports assigned to the PMM Server (e.g., `55000` and `55001`).
   - Click "Next".

5. Allow the connection:
   - Select "Allow the connection" and click "Next".

6. Specify the profiles:
   - Check all profiles (Domain, Private, Public) and click "Next".

7. Name the rule:
   - Enter a name for the rule (e.g., "PMM Server Ports").
   - Click "Finish".

Repeat the steps to create another inbound rule for the HTTPS port if needed.

## Step 4: Connect PMM Client to PMM Server

1. On your Ubuntu machine, configure the PMM Client to connect to the PMM Server:

    ```sh
    sudo pmm-admin config --server-insecure-tls --server-url=https://admin:admin@<PMM-Server-IP>:<PMM-Server-HTTPS-Port>
    ```

    Replace `<PMM-Server-IP>` with the IP address of your PMM Server and `<PMM-Server-HTTPS-Port>` with the HTTPS port assigned to the PMM Server (e.g., `55001`).

2. Verify the connection to the PMM Server:

    ```sh
    pmm-admin status
    ```

    The output should confirm that the PMM Client is connected to the PMM Server.

## Step 5: Add MySQL Instance to PMM Monitoring

1. On your Ubuntu machine, add a MySQL instance to PMM monitoring:

    ```sh
    sudo pmm-admin add mysql --username=<MySQL-Username> --password=<MySQL-Password> --host=<MySQL-Host> --port=<MySQL-Port>
    ```

    Replace `<MySQL-Username>`, `<MySQL-Password>`, `<MySQL-Host>`, and `<MySQL-Port>` with your MySQL instance's credentials and connection details.

2. Verify that the MySQL instance has been added:

    ```sh
    pmm-admin list
    ```

    The output should list the MySQL instance, confirming that it has been successfully added to PMM monitoring.

## Conclusion

You have successfully set up the PMM Server using Docker Desktop UI, the PMM Client on an Ubuntu system, opened the necessary ports on Windows Defender Firewall, connected the PMM Client to the PMM Server, and added a MySQL instance to PMM monitoring.