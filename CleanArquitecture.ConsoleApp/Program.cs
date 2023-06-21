﻿using CleanArquitecture.Data;
using CleanArquitecture.Domain;
using Microsoft.EntityFrameworkCore;

StreamerDbContext dbContext = new();

//await AddNewRecords();
//QueryStreaming();
//await QueryFilter();
//await QueryMethods();
//await QueryLinq();
//await TrackingAndNotTracking();
//await AddNewStreamerWithVideo();
//await AddNewStreamerWithVideoId();
//await AddNewActorWithVideo();
//await AddNewDirectorWithVideo();
await MultipleEntitiesQuery();

Console.WriteLine("Presione cualquier tecla para terminar el programa");
Console.ReadKey();

async Task MultipleEntitiesQuery()
{
    //var videoWithActores = await dbContext!.Videos!.Include(x => x.Actores).FirstOrDefaultAsync(x => x.Id == 1);
    //var actor = await dbContext.Actores!.Select(x => x.Nombre).ToListAsync();

    var videoWithDirector = await dbContext!.Videos!
                            .Where(x => x.Director != null)
                            .Include(x => x.Director)
                            .Select(q =>
                                new {
                                    Director_NombreCompleto = $"{q.Director.Nombre} {q.Director.Apellido}",
                                    Movie = q.Nombre
                                }
                            )
                            .ToListAsync();

    foreach ( var pelicula in videoWithDirector)
    {
        Console.WriteLine($"{pelicula.Movie} - {pelicula.Director_NombreCompleto}");
    }
}

async Task AddNewDirectorWithVideo()
{
    var director = new Director
    {
        Nombre = "Lorenzo",
        Apellido = "Bazteri",
        VideoId = 1
    };

    await dbContext.AddAsync(director);
    await dbContext.SaveChangesAsync();
}

async Task AddNewActorWithVideo()
{
    var actor = new Actor
    {
        Nombre = "Brad",
        Apellido = "Pitt"
    };

    await dbContext.AddAsync(actor);
    await dbContext.SaveChangesAsync();

    var videoActor = new VideoActor
    {
        ActorId = actor.Id,
        VideoId = 1
    };

    await dbContext.AddAsync(videoActor);
    await dbContext.SaveChangesAsync();
}

async Task AddNewStreamerWithVideoId()
{
    var batmanForever = new Video
    {
        Nombre = "Batman Forever",
        StreamerId = 4
    };

    await dbContext.AddAsync(batmanForever);
    await dbContext.SaveChangesAsync();
}

async Task AddNewStreamerWithVideo()
{
    var pantaya = new Streamer 
    {
        Nombre = "Pantaya"
    };
    var hungerGames = new Video
    {
        Nombre = "Hunger Games",
        Streamer = pantaya
    };

    await dbContext.AddAsync(hungerGames);
    await dbContext.SaveChangesAsync();
}

async Task TrackingAndNotTracking()
{
    var streamerWithTracking = await dbContext.Streamers!.FirstOrDefaultAsync(x => x.Id == 1);
    var streamerWithNoTracking = await dbContext.Streamers!.AsNoTracking().FirstOrDefaultAsync(x => x.Id == 2);

    streamerWithTracking.Nombre = "Netflix Super";
    streamerWithNoTracking.Nombre = "Amazon Plus";

    await dbContext!.SaveChangesAsync();
}

async Task QueryLinq()
{
    Console.WriteLine("Ingresa una compañia de streaming:");
    var streamerNombre = Console.ReadLine();

    var streamers = await (from i in dbContext.Streamers where EF.Functions.Like(i.Nombre, $"{streamerNombre}") select i).ToListAsync();

    foreach (var streamer in streamers)
    {
        Console.WriteLine($"{streamer.Id} - {streamer.Nombre}");
    }
}

async Task QueryMethods()
{
    var streamer = dbContext!.Streamers!;

    var firstAsync = await streamer.Where(x => x.Nombre!.Contains("a")).FirstAsync();
    var firstOrDefaultAsync = await streamer.Where(x => x.Nombre!.Contains("a")).FirstOrDefaultAsync();
    var firstOrDefaultAsync2 = await streamer.FirstOrDefaultAsync(x => x.Nombre!.Contains("a"));

    var singleAsync = await streamer.Where(x => x.Id == 1).SingleAsync();
    var singleOrDefaultAsync = await streamer.Where(x => x.Id == 1).SingleOrDefaultAsync();

    var resultado = await streamer.FindAsync(1);
}

async Task QueryFilter()
{
    Console.WriteLine("Ingresa una compañia de streaming:");
    var streamingNombre = Console.ReadLine();

    var streamers = await dbContext!.Streamers!.Where(x => x.Nombre!.Equals(streamingNombre)).ToListAsync();

    foreach (var streamer in streamers)
    {
        Console.WriteLine($"{streamer.Id} - {streamer.Nombre}");
    }

    var streamerPartialResult = await dbContext!.Streamers!.Where(x => x.Nombre!.Contains(streamingNombre)).ToListAsync();
    //var streamerPartialResult = await dbContext!.Streamers!.Where(x =>  EF.Functions.Like(x.Nombre, $"%{streamingNombre}%")).ToListAsync();

    foreach (var streamer in streamerPartialResult)
    {
        Console.WriteLine($"{streamer.Id} - {streamer.Nombre}");
    }
}

void QueryStreaming()
{
    var streamers = dbContext!.Streamers!.ToList();

    foreach (var streamer in streamers)
    {
        Console.WriteLine($"{streamer.Id} - {streamer.Nombre}");
    }
}

async Task AddNewRecords()
{
    Streamer streamer = new()
    {
        Nombre = "Disney",
        Url = "https://www.disneyplus.com"
    };

    dbContext!.Streamers!.Add(streamer);

    await dbContext.SaveChangesAsync();

    var movies = new List<Video>
    {
        new Video
        {
            Nombre = "La cenicienta",
            StreamerId = streamer.Id
        },
        new Video
        {
            Nombre = "101 Dalmatas",
            StreamerId = streamer.Id
        },
        new Video
        {
            Nombre = "El jorobado de notredame",
            StreamerId = streamer.Id
        },
        new Video
        {
            Nombre = "Star Wars",
            StreamerId = streamer.Id
        }
    };

        await dbContext.AddRangeAsync(movies);
        await dbContext.SaveChangesAsync();
}