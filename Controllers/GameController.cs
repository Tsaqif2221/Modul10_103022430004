using Microsoft.AspNetCore.Mvc;
using Modul10_103022430004.Models;
using System;
using System.Collections.Generic;
using System.Reflection;
namespace Modul10_103022430004.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameController : ControllerBase
    {
        private static List<Game> games = new List<Game>
        {
            new Game {Id = 1, Nama = "Valorant",  Developer = "Riot Games", TahunRilis = 2020, Genre = "FPS", Rating = 8.5, Platform = new string[] {"PC"}, Mode = new string[] {"Multiplayer" }, IsOnline = true, Harga = 0},
            new Game {Id = 2, Nama = "GTA V",  Developer = "Rockstar Games", TahunRilis = 2013, Genre = "Open World", Rating = 9.5, Platform = new string[] {"PC","PS4", "PS5", "Xbox"}, Mode = new string[] { "Singleplayer", "Multiplayer" }, IsOnline = true, Harga = 300000},
            new Game {Id = 3, Nama = "The Witcher 3",  Developer = "CD Projekt Red", TahunRilis = 2015, Genre = "RPG", Rating = 9.7, Platform = new string[] {"PC","PS4", "PS5", "Xbox", "Switch"}, Mode = new string[] {"Singleplayer" }, IsOnline = false, Harga = 250000},
        };
        [HttpGet]
        public ActionResult<List<Game>> GetAll()
        {
            return Ok(games);
        }
        [HttpGet("{index:int}")]
        public ActionResult<Game> GetbyIndex(int index)
        {
            if (index < 1 || index > games.Count)
            {
                return NotFound($"Index {index} tidak valid");
            }
            return Ok(games[index - 1]);
        }
        [HttpPost]
        public ActionResult Create([FromBody] Game newGame)
        {
            games.Add(newGame);
            return CreatedAtAction(nameof(GetbyIndex), new { index = games.Count }, newGame);
        }
        [HttpPut("{index:int}")]
        public ActionResult Update([FromRoute]int index, Game updateGame)
        {
            var id = games.FindIndex(g => g.Id == index);
            if (id < 1 || id > games.Count)
            {
                return NotFound($"Index {id} tidak valid");
            }
            games[index] = updateGame;
            return Ok(games[index - 1]);
        }
        [HttpDelete("{index:int}")]
        public ActionResult Delete(int index)
        {
            if(index < 1 || index > games.Count)
            {
                return NotFound($"Index {index} tidak valid");
            }
            games.RemoveAt(index - 1);
            return NoContent();
        }
    }
}
