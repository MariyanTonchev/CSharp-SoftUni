namespace MusicHub
{
    using System;
    using System.Globalization;
    using System.Text;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Internal;

    public class StartUp
    {
        public static void Main()
        {
            MusicHubDbContext context =
                new MusicHubDbContext();

            //DbInitializer.ResetDatabase(context);

            //Console.WriteLine(ExportAlbumsInfo(context, 9));

            Console.WriteLine(ExportSongsAboveDuration(context, 4));
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var albumsInfo = context.Producers
                .Include(producer => producer.Albums)
                    .ThenInclude(album => album.Songs)
                        .ThenInclude(song => song.Writer)
                .FirstOrDefault(p => p.Id == producerId)!
                .Albums.Select(album => new
                {
                    AlbumName = album.Name,
                    ReleaseDate = album.ReleaseDate,
                    ProducerName = album.Producer.Name,
                    Songs = album.Songs
                        .OrderByDescending(song => song.Name)
                        .ThenBy(song => song.Writer.Name)
                        .Select(song => new
                        {
                            SongName = song.Name,
                            Price = song.Price,
                            Writer = song.Writer.Name
                        }),
                        
                    TotalAlbumPrice = album.Price
                })
                .OrderByDescending(album => album.TotalAlbumPrice)
                .AsEnumerable();

            StringBuilder stringBuilder = new StringBuilder();

            foreach(var album in albumsInfo)
            {
                stringBuilder
                    .AppendLine($"-AlbumName: {album.AlbumName}")
                    .AppendLine($"-ReleaseDate: {album.ReleaseDate.ToString("MM/dd/yyyy", CultureInfo.InvariantCulture)}")
                    .AppendLine($"-ProducerName: {album.ProducerName}")
                    .AppendLine($"-Songs:");

                    int index = 1;

                    foreach(var song in album.Songs)
                    {
                    stringBuilder
                        .AppendLine($"---#{index}")
                        .AppendLine($"---SongName: {song.SongName}")
                        .AppendLine($"---Price: {song.Price.ToString("F2", CultureInfo.InvariantCulture)}")
                        .AppendLine($"---Writer: {song.Writer}");

                    index++;
                    }

                stringBuilder
                    .AppendLine($"-AlbumPrice: {album.TotalAlbumPrice.ToString("F2", CultureInfo.InvariantCulture)}");
            }

            string result = stringBuilder.ToString().TrimEnd();

            return result;
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            var span = new TimeSpan(0, 0, duration);
            var songsAboveDuration = context.Songs
                .Where(song => song.Duration > span)
                .Select(song => new
                {
                    SongName = song.Name,
                    PerformerFullName = song.SongPerformers
                        .Select(sp => sp.Performer.FirstName + " " + sp.Performer.LastName)
                        .OrderBy(name => name)
                        .ToList(),
                    WriterName = song.Writer.Name,
                    AlbumProducerName = song.Album.Producer.Name,
                    Duration = song.Duration.ToString("c")
                })
                .OrderBy(song => song.SongName)
                .ThenBy(song => song.WriterName)
                .ToList();

            StringBuilder sb = new StringBuilder();
            int counter = 1;

            foreach (var song in songsAboveDuration)
            {
                sb.AppendLine($"-Song #{counter++}")
                  .AppendLine($"---SongName: {song.SongName}")
                  .AppendLine($"---Writer: {song.WriterName}");

                if (song.PerformerFullName.Any())
                {
                    sb.AppendLine(string.Join(Environment.NewLine, song.PerformerFullName.Select(p => $"---Performer: {p}")));
                }

                sb.AppendLine($"---AlbumProducer: {song.AlbumProducerName}")
                  .AppendLine($"---Duration: {song.Duration}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
