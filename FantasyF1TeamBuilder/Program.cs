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

// Prompt User for Team Budget
var budget = ConsoleHelper.PromptForBudget();

// Create fantasy data services
var fantasyConstructorService = new CSVConstructorService(resultSettings);
var fantasyDriverService = new CSVDriverService(resultSettings);

// Create statistical services
var driverStatisticsService = new CSVDriverResultService(statisticsSettings);
var constructorStatisticsService = new CSVConstructorResultService(statisticsSettings);

// Get Prediction Engines
var driverPredictionEngine = PredictionEngineBuilder.BuildDriverEngine();
var constructorPredictionEngine = PredictionEngineBuilder.BuildConstructorEngine();

// Get drivers with predicted scores
var drivers = await fantasyDriverService.GetDriverData();
var driverRaceResuls = await driverStatisticsService.GetResults();

//ToDo: Clean this up - use a better mechanism than Zip
var driversAndResults = drivers.OrderBy(d => d.Name).Zip(driverRaceResuls.OrderBy(r => r.Name));
foreach (var (driver, results) in driversAndResults) 
{
	driver.BasePoints = driverPredictionEngine.PredictPoints(results);
}

var constructors = await fantasyConstructorService.GetConstructorData();
var constructorRaceResults = await constructorStatisticsService.GetResults();

var constructorsAndResults = constructors.OrderBy(d => d.Name).Zip(constructorRaceResults.OrderBy(r => r.Name));
foreach (var (constructor, results) in constructorsAndResults)
{
	constructor.BasePoints = constructorPredictionEngine.PredictPoints(results);
}

// Build Team
var teamOptimizer = new BruteForceTeamBuilder();
var bestTeam = teamOptimizer.BuildOptimizedTeam(drivers, constructors, budget);

// Output results
ConsoleHelper.PrintTeam(bestTeam);
