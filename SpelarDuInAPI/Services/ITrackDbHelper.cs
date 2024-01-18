﻿using Microsoft.EntityFrameworkCore;
using SpelarDuInAPI.Data;
using SpelarDuInAPI.Models;
using SpelarDuInAPI.Models.DTO;
using SpelarDuInAPI.Models.ViewModels;
using System;
using System.Net;

namespace SpelarDuInAPI.Services
{
    public interface ITrackDbHelper
    {
        void AddNewTrack(TrackDto trackDto);
        TrackViewModel[] GetAllTracksFromSingleUser(int userId);
    }
    public class TrackDbHelper : ITrackDbHelper
    {
        private ApplicationContext _context;

        public TrackDbHelper(ApplicationContext context)
        {
            _context = context;
        }
        public void AddNewTrack(TrackDto trackDto)
        {
            //Find or create genre
            var genre = _context.Genres
                .FirstOrDefault(g => g.GenreName == trackDto.Genre);
            if (genre == null)
            {
                genre = new Genre
                {
                    GenreName = trackDto.Genre
                };
                _context.Genres.Add(genre);
            }
            //Find or create artist
            var artist = _context.Artists
                .FirstOrDefault(a => a.ArtistName == trackDto.Artist);
            if (artist == null)
            {
                artist = new Artist
                {
                    ArtistName = trackDto.Artist
                };
                _context.Artists.Add(artist);
            }
            //create new track 
            var newTrack = new Track
            {
                TrackTitle = trackDto.TrackTitle,
                Artist = artist,
                Genre = genre,
            };
            _context.Tracks.Add(newTrack);
            _context.SaveChanges();

            
          }

        public TrackViewModel[] GetAllTracksFromSingleUser(int userId)
        {
            //Find user
            var user = _context.Users
                .Include(u => u.Tracks)
                .FirstOrDefault(u => u.Id == userId);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            //Show all tracktitles
            var result = user.Tracks
                .Select(r => new TrackViewModel
                {
                    Id = r.Id,
                    TrackTitle = r.TrackTitle
                }).ToArray();
            return result;
        }
    }
}