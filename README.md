![Hackathon Logo](docs/images/hackathon.png?raw=true "Hackathon Logo")
# Sitecore Hackathon 2024

- MUST READ: **[Submission requirements](SUBMISSION_REQUIREMENTS.md)**
  
# Hackathon Submission Entry form

## Team name
⟹ Tigretones

## Category
⟹ Best use of AI

## Module Name: AI-Powered SEO Optimization Tool for Sitecore

## Description
AI-Powered SEO Optimization Tool is a Sitecore module that leverages AI algorithms to optimize website content for search engines. The tool could analyze pages content, identify keywords, meta tags, and suggest improvements to enhance SEO performance.

## Module Purpose
The AI-Powered SEO Optimization Tool for Sitecore is designed to streamline and enhance the process of optimizing website content for search engines. By integrating AI algorithms and leveraging Google's Gemini API through a .NET Core middleware, the module provides Sitecore users with advanced capabilities to improve their website's search engine visibility and drive organic traffic.

## What problem was solved
Prior to the development of this module, Sitecore users faced challenges in efficiently optimizing their website content for search engines. Manual keyword research, meta tag optimization, and content analysis processes were time-consuming and often resulted in suboptimal SEO performance. Additionally, ensuring consistency and compliance with SEO best practices across all pages of a website was a daunting task.

## How does this module solve it
The AI-Powered SEO Optimization Tool addresses these challenges by automating and enhancing the SEO optimization process within Sitecore. By connecting to a .NET Core API that serves as a middleware for Google's Gemini API, the module harnesses the power of AI algorithms to analyze page content, identify relevant keywords, and suggest improvements for meta tags (title, meta description, and keywords).

Key features of the module include:

- Automated Content Analysis: The module automatically analyzes website pages' content to identify keywords and phrases that are relevant to the page's topic and target audience.
- AI-Powered Keyword Suggestions: Leveraging Google's Gemini API, the module suggests relevant keywords and phrases that can be incorporated into the page's meta tags to improve search engine visibility.
- Meta Tag Optimization: The module provides recommendations for optimizing meta tags, including titles, meta descriptions, and keywords, based on SEO best practices and AI-driven insights.
- Performance Analytics: The module enhances user experience by providing a Headless Dashboard built using Astro JS. This dashboard allows users to visualize the changes made to their website content, facilitating collaboration and enabling quick previews of optimized pages.

Overall, the AI-Powered SEO Optimization Tool empowers Sitecore users to enhance their website's SEO performance, increase organic traffic, and improve their visibility in search engine results pages, ultimately driving business growth and success.

## Video link

⟹ [Demo video](https://youtu.be/7AYWwRQK4x4?si=5Tbh33oUm_LMAUmm)

## Pre-requisites and Dependencies

⟹ AI-Powered SEO Optimization Sitecore Module

## Dependencies
- Sitecore Sxa 10.3.1
- Sitecore Headless Services for Sitecore XP

⟹ Gemini AI Middleware

## Dependencies
- Net Core 8

⟹ Headless Dashboard

## Dependencies
- NodeJS 20+

## Installation instructions

⟹ AI-Powered SEO Optimization Sitecore Module  

To install the AI-Powered SEO Optimization Tool, go to the Sitecore Installation Wizard, and select the zip file in the folder 2024-Tigretones\Packages (from the git source control). The file contains the templates, script modules, sample data and a sample page. 

The only restriction is that the new page needs to inherit from the SEO Optimization Template, because the script validates this inheritance. The new page contains 6 fields that comes from the template.

⟹ Gemini AI Middleware  

1. Prerequisites:
Install .NET Core 8 SDK on your machine. You can download it from the official .NET website. https://dotnet.microsoft.com/en-us/download/dotnet/8.0

2. Clone the Project:
Clone the project repository from the source (if available) or download it as a ZIP file and extract it to your local machine.

3. Configuration:
Navigate to the project directory \Sitecore-Hackathon\2024-Tigretones\src\Feature\SEO\IASearchEngineOptimization\GeminiAPI and locate the appsettings.json file.
Open the appsettings.json file and configure the following settings:

- urls: Specify the URL where the application will be hosted. By default, it's set to https://*:5003.
- Under the "Gemini" section, add or update the "ApiKey" (Not required).

4. API Key Setup (Update not required):
We are providing a functional API key for demo purposes.

5. Run the Application:
- Open a terminal or command prompt and navigate to the project directory \Sitecore-Hackathon\2024-Tigretones\src\Feature\SEO\IASearchEngineOptimization\GeminiAPI
- Run the following command to build and run the application: dotnet run

This command will compile the application and start the server. Once the server is up and running, it will listen for incoming requests.

⟹ Headless Dashboard

1. Open a terminal or command prompt and navigate to the project directory \Sitecore-Hackathon\2024-Tigretones\src\Frontend
   
2. Run the following command to build and run the application: npm install

## Usage instructions

⟹ AI-Powered SEO Optimization Sitecore Module  

The next steps explains a sample of how to use the tool Title Tag, Meta Description, Keywords for the current SEO tags and Title Tag Previous, Meta Description Previous, Keywords Previous to store the replaced data.

1. Right click on the item and then select: Scripts \ AI-Powered SEO Optimization.

![Step 1](docs/images/01.png?raw=true "Step 1")

2. Select the tags that you need to generate with AI and then selected the AI Prompt to execute.

![Step 2](docs/images/02.png?raw=true "Step 2")

3. In the example the Title Tag Field updated with a new value that comes from the AI execution.

![Step 3](docs/images/03.png?raw=true "Step 3")

4. The old data was stored in the Title Tag Previous Field.

![Step 4](docs/images/03.png?raw=true "Step 4")

5. Changes are visible on Dashboard

![Dashboard](docs/images/Dashboard.png?raw=true "Dashboard")

