Progress Store Tests
============================

## Prerequisite
 - Visual Studio 2022 Community (recommended)
 - .NET SDK 6.0
 - .NET Runtime 6.0
 - ASP.NET Core Runtime 6.0
 - Selenium Chrome Driver and browser

## Introduction
Progress Store is a test project that executes TDD and BDD Selenium test cases/scenarios on https://www.progress.com/ website.

## Project Structure
Solution is comprised from following folders and few general C# classes:
- Features: contains BDD feature files (Gerkins) and auto generated corresponding classes
- Models: contains CSS selector classes from POM (Page Object Model) design pattern
- Pages: contains specific POM realization for each individual page as a general abstraction from HTML representation
- StepDefinitions: contains binding classes to BDD Gerkin scenarios
- Tests: contains specific TDD test cases for each page

## Running the tests
In Visual Studio Test Explorer (Windows) / Test view (Mac) Run Progress_Store. This will trigger all feature (BDD) and TDD tests