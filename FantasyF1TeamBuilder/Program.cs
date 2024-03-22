// See https://aka.ms/new-console-template for more information
using Analytics;
using Builders;
using Configuration;
using Fantasy.Services;
using FantasyF1TeamBuilder;
using Results.Services;

// Load configuration
var configuration = new ApplicationConfiguration();

var resultSettings = configuration.FantasySettings;
var statisticsSettings = configuration.StatisticsSettings;

// Create fantasy data services
var fantasyConstructorService = new CSVConstructorService(resultSettings);
var fantasyDriverService = new CSVDriverService(resultSettings);

// Create statistical services
var driverResultService = new CSVDriverResultService(statisticsSettings);
var constructorResultService = new CSVConstructorResultService(statisticsSettings);

// Get Prediction Engines
var driverPredictionEngine = PredictionEngineBuilder.BuildDriverEngine();
var constructorPredictionEngine = PredictionEngineBuilder.BuildConstructorEngine();

// Predict Results
var drivers = await PredictionHelper.BuildDriverPredictions(fantasyDriverService, driverResultService, driverPredictionEngine);
var constructors = await PredictionHelper.BuildConstructorPredictions(fantasyConstructorService, constructorResultService, constructorPredictionEngine);

// Prompt User for Team Budget
var budget = ConsoleHelper.PromptForBudget();

// Build Team
var teamOptimizer = new BruteForceTeamBuilder();
var bestTeam = teamOptimizer.BuildOptimizedTeam(drivers, constructors, budget);

// Output results
ConsoleHelper.PrintTeam(bestTeam);
