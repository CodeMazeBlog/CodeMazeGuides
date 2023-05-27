using PhotoFilters.Delegates;
using PhotoFilters.Filters;
using PhotoFilters.Models;
using PhotoFilters.v02.Filters;

Photo photo = new("path");

PhotoProcessor processor = new PhotoProcessor();

PhotoProcessor.PhotoProcessorHandler processorHandler = Brightness.ApplyBrightness;
processorHandler += Contrast.ContrastPhoto;
processorHandler += NoiseReduction.SuppressWhiteNoise;

Console.WriteLine("Custom Delegate");
var newPhoto = processor.Process(photo, processorHandler);

FuncPhotoProcessor funcPhotoProcessor = new FuncPhotoProcessor();
Func<Photo, Photo> funcProcessorHandler = Brightness.ApplyBrightness;

Console.WriteLine("Function Delegate");
var fPhoto = funcPhotoProcessor.Process(photo, funcProcessorHandler);


ActionPhotoProcessor actionPhotoProcessor = new ActionPhotoProcessor();
Action<Photo> actionProcessorHandler = Brightness.ApplyBrightnessAndSave;

Console.WriteLine("Action Delegate");
actionPhotoProcessor.Process(photo, actionProcessorHandler);
