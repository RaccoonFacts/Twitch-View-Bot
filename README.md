# Twitch Viewer Bot


![Status](https://img.shields.io/badge/status-experimental-red)  

![image](https://github.com/user-attachments/assets/f0fe3926-5828-485e-bdaa-b183adccaa08)


A simple Windows Forms application that uses **Selenium WebDriver** and **Tor** to simulate viewers on a Twitch channel. This project is intended as an educational example of automating browser instances with Selenium and routing traffic through Tor for anonymity. **Note:** This is an experimental project and does not fully work as intended—use it as a starting point or reference rather than a production-ready tool.

## Features
- Launches multiple headless Chrome instances via Selenium.
- Routes browser traffic through the Tor network for IP anonymization.
- Automatically sets video quality to 160p to minimize bandwidth.
- Configurable viewer count, refresh interval, and target Twitch channel.
- Basic logging for debugging and monitoring.

## Prerequisites
- **Windows OS** (due to Windows Forms dependency).
- [.NET Framework](https://dotnet.microsoft.com/en-us/download/dotnet-framework) (version compatible with your project, e.g., 4.8).
- [Tor Browser](https://www.torproject.org/download/) installed at `C:\Users\<YourUsername>\Desktop\Tor Browser\` (or adjust the path in code).
- [ChromeDriver](https://chromedriver.chromium.org/downloads) matching your installed Chrome version.
- Google Chrome installed.

## Installation
1. **Clone the Repository:**
   ```bash
   git clone https://github.com/raccoonfacts/Twitch-View-bot.git
   cd <twitch-view-bot>
