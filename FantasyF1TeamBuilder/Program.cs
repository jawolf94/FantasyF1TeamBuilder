﻿// See https://aka.ms/new-console-template for more information
using Configuration;
using FantasyF1TeamBuilder;
using Predictors;
using Predictors.PredictedComponents;
using Services.FantasyData;
using Services.FantasyData.CSV;
using Services.TeamBuilder;

// Load configuration
var configuration = new ApplicationConfiguration();
var resultSettings = configuration.ResultSettings;

// Get Fantasy Data
var constructorService = new CSVConstructorDataService(resultSettings);
var driverDataService = new CSVDriverDataService(resultSettings);
var resultService = new FantasyDataService(constructorService, driverDataService);

// Get Prediction Engines
var driverPredictionEngine = PredictionEngineHelper.BuildDriverPredictionEngine();
var constructorPredictionEngine = PredictionEngineHelper.BuildConstructorPredictionEngine();

// Predict Scores
var drivers = await resultService.GetDriverData();
var driverPredictions = drivers.Select(d => new PredictedDriver(d, driverPredictionEngine)).ToList();

var constructors = await resultService.GetConstructorData();
var constructorPredictions = constructors.Select(c => new PredictedConstructor(c, constructorPredictionEngine)).ToList();

// Build Team
var teamOptimizer = new BruteForceTeamBuilder();
var bestTeam = teamOptimizer.OptimizeTeam(driverPredictions, constructorPredictions, 100m);

// Output results
OutputHelper.PrintTeam(bestTeam);

