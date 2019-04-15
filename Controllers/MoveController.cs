using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
//using fresh.Models;

namespace ht22.Controllers
{

    public class Move
    {
        public string gameId { get; set; }
        public string color { get; set; }
        public string moveFrom { get; set; }
        public string moveTo { get; set; }
    }

    public class VisualBoardStore
    {
        // There's just one board per game, but each game has different hue maps for each player.
        protected static Dictionary<string, Dictionary<string, string>> m_allPieces = new Dictionary<string, Dictionary<string, string>>();
        protected static Dictionary<string, Dictionary<HexC.ColorsEnum, Dictionary<string, string>>> m_allHues = new Dictionary<string, Dictionary<HexC.ColorsEnum, Dictionary<string, string>>>();

        public static void KillBoard(string gameid)
        {
            m_allPieces.Remove(gameid);
            m_allHues.Remove(gameid);
        }

        public static void AddBoard(string id, Dictionary<string, string> board)
        {
            m_allPieces.Add(id, board);
            m_allHues.Add(id, new Dictionary<HexC.ColorsEnum, Dictionary<string, string>>());
            m_allHues[id].Add(HexC.ColorsEnum.White, new Dictionary<string, string>());
         // what is this about???   m_allHues[id][HexC.ColorsEnum.White].Add("n0_n0", "9,9,9,1.0");
            m_allHues[id].Add(HexC.ColorsEnum.Black, new Dictionary<string, string>());
            m_allHues[id].Add(HexC.ColorsEnum.Tan, new Dictionary<string, string>());
        }

        public static bool ContainsGame(string id) { return m_allPieces.ContainsKey(id); }
        public static Dictionary<string,string> GameBoard(string id) { if(m_allPieces.ContainsKey(id)) return m_allPieces[id]; return null; }
        public static Dictionary<string,string> Hues(string id, string color) { return m_allHues[id][ColorEnumFromString(color)]; }
        public static void ReplaceHues(string id, string color, Dictionary<string, string> hues)
        {
            HexC.ColorsEnum col = ColorEnumFromString(color);
            m_allHues[id][col] = hues;
        }

        protected static HexC.ColorsEnum ColorEnumFromString( string color )
        {
            HexC.ColorsEnum col = HexC.ColorsEnum.White;
            switch (color)
            {
                case "black": col = HexC.ColorsEnum.Black; break;
                case "tan": col = HexC.ColorsEnum.Tan; break;
            }
            return col;
        }
    }

    [Controller]
    public class MoveController : Controller
    {
        public MoveController() {        }

        void MakeCertainGameExists(string id)
        {
            if (VisualBoardStore.ContainsGame(id))
                return;

            Dictionary<string, string> board = new Dictionary<string, string>();


            board.Add("n0_n0", "XX");
            board.Add("n0_n1", "XX");
            board.Add("n0_n2", "XX");
            board.Add("n0_n3", "XX");
            board.Add("n0_n4", "XX");
            board.Add("n0_n5", "XX");
            board.Add("n0_p1", "XX");
            board.Add("n0_p2", "XX");
            board.Add("n0_p3", "XX");
            board.Add("n0_p4", "XX");
            board.Add("n0_p5", "XX");
            board.Add("n1_n0", "XX");
            board.Add("n1_p1", "XX");
            board.Add("n2_n0", "XX");
            board.Add("n2_p1", "XX");
            board.Add("n2_p2", "XX");
            board.Add("n3_n0", "XX");
            board.Add("n3_p1", "XX");
            board.Add("n3_p2", "XX");
            board.Add("n3_p3", "XX");
            board.Add("n4_n2", "XX");
            board.Add("n4_p1", "XX");
            board.Add("n4_p2", "XX");
            board.Add("n4_p3", "XX");
            board.Add("n4_p4", "XX");
            board.Add("n5_n0", "XX");
            board.Add("n5_n1", "XX");
            board.Add("n5_n2", "XX");
            board.Add("n5_p1", "XX");
            board.Add("n5_p2", "XX");
            board.Add("n5_p3", "XX");
            board.Add("n5_p4", "XX");
            board.Add("n5_p5", "XX");
            board.Add("p1_n0", "XX");
            board.Add("p1_n1", "XX");
            board.Add("p1_n2", "XX");
            board.Add("p1_n3", "XX");
            board.Add("p1_n4", "XX");
            board.Add("p1_n5", "XX");
            board.Add("p1_p1", "XX");
            board.Add("p1_p2", "XX");
            board.Add("p1_p3", "XX");
            board.Add("p1_p4", "XX");
            board.Add("p1_p5", "XX");
            board.Add("p2_n0", "XX");
            board.Add("p2_n2", "XX");
            board.Add("p2_n3", "XX");
            board.Add("p2_n4", "XX");
            board.Add("p2_n5", "XX");
            board.Add("p2_p1", "XX");
            board.Add("p2_p2", "XX");
            board.Add("p2_p3", "XX");
            board.Add("p2_p4", "XX");
            board.Add("p3_n0", "XX");
            board.Add("n4_n0", "XX");
            board.Add("p3_n3", "XX");
            board.Add("p3_n4", "XX");
            board.Add("p3_n5", "XX");
            board.Add("p3_p1", "XX");
            board.Add("p3_p2", "XX");
            board.Add("p3_p3", "XX");
            board.Add("p3_p4", "XX");
            board.Add("p4_n0", "XX");
            board.Add("p4_n4", "XX");
            board.Add("p4_n5", "XX");
            board.Add("p4_p1", "XX");
            board.Add("p4_p2", "XX");
            board.Add("p5_n0", "XX");
            board.Add("p5_n5", "XX");
            board.Add("p5_p3", "XX");
            board.Add("WV_01", "XX");
            board.Add("WV_02", "XX");
            board.Add("WV_03", "XX");
            board.Add("WV_04", "XX");
            board.Add("WV_05", "XX");
            board.Add("WV_06", "XX");
            board.Add("WV_07", "XX");
            board.Add("WV_08", "XX");
            board.Add("WV_09", "XX");
            board.Add("WV_10", "XX");
            board.Add("WV_11", "XX");
            board.Add("WV_12", "XX");
            board.Add("WV_13", "XX");
            board.Add("TV_01", "XX");
            board.Add("TV_02", "XX");
            board.Add("TV_03", "XX");
            board.Add("TV_04", "XX");
            board.Add("TV_05", "XX");
            board.Add("TV_06", "XX");
            board.Add("TV_07", "XX");
            board.Add("TV_08", "XX");
            board.Add("TV_09", "XX");
            board.Add("TV_10", "XX");
            board.Add("TV_11", "XX");
            board.Add("TV_12", "XX");
            board.Add("TV_13", "XX");
            board.Add("BV_01", "XX");
            board.Add("BV_02", "XX");
            board.Add("BV_03", "XX");
            board.Add("BV_04", "XX");
            board.Add("BV_05", "XX");
            board.Add("BV_06", "XX");
            board.Add("BV_07", "XX");
            board.Add("BV_08", "XX");
            board.Add("BV_09", "XX");
            board.Add("BV_10", "XX");
            board.Add("BV_11", "XX");
            board.Add("BV_12", "XX");
            board.Add("BV_13", "XX");

            board.Add("n3_n2", "TK");
            board.Add("n3_p5", "WK");
            board.Add("p5_n2", "BK");



        //    board.Add("n1_p2", "WC");
         //   board.Add("n1_n1", "WP");

            board.Add("n1_p2", "WP");
            board.Add("n1_n1", "TP");
            board.Add("n1_n2", "TP");
            board.Add("n1_n3", "TE");
            board.Add("n1_n4", "TC");
            board.Add("n1_p3", "WP");
            board.Add("n1_p4", "WE");
            board.Add("n1_p5", "WC");
            board.Add("n2_n1", "TP");
            board.Add("n2_n2", "TE");
            board.Add("n2_n3", "TQ");
            board.Add("n2_p3", "WP");
            board.Add("n2_p4", "WE");
            board.Add("n2_p5", "WQ");
            board.Add("n3_n1", "TE");
            board.Add("n3_p4", "WE");
            board.Add("n4_n1", "TC");
            board.Add("n4_p5", "WC");
            board.Add("p2_n1", "BP");
            board.Add("p3_n1", "BP");
            board.Add("p3_n2", "BP");
            board.Add("p4_n1", "BE");
            board.Add("p4_n2", "BE");
            board.Add("p4_n3", "BE");
            board.Add("p5_n1", "BC");
            board.Add("p5_n3", "BQ");
            board.Add("p5_n4", "BC");

            VisualBoardStore.AddBoard(id, board);
            VisualBoardStore.AddBoard(id + "SNAPSHOT", board);
            
            // allHues.Add(id, new Dictionary<string, string>());
        }

        [HttpPost]
        public IActionResult Pieces([FromBody] Move move)
        {
            System.Threading.Semaphore s = new System.Threading.Semaphore(1, 1, "COPS"); s.WaitOne();
            try
            {
                MakeCertainGameExists(move.gameId);
                var board = VisualBoardStore.GameBoard(move.gameId); // allPieces[move.gameId];

                string movefrom = move.moveFrom.Substring(0, 5);

                /* not happening cuz i can't click a piece as my targ. 
                if (board[move.moveTo][1] == 'Q')
                    if (board[movefrom][1] == 'K')
                    {
                        string tmp = board[move.moveTo];
                        board[move.moveTo] = board[movefrom];
                        board[movefrom] = tmp;
                    }
                    */

                if (board[move.moveTo] == "XX")
                {
                    board[move.moveTo] = board[movefrom];
                    board[movefrom] = "XX";
                }
                else
                {
                    // you're moving to a spot that contains a piece.
                    // is it an opponent piece?
                    // well i don't care.
                    // if I'm attacking a piece, i'd be so cool if i:
                    // 1. moved that piece to limbo, 
                    // 2. moved same-color same-piece FROM limbo if possible.
                    // (if portal is occupied, then it's not possible).
                }

                Response.Headers.Add("Access-Control-Allow-Origin", "*");
                return Ok();
            }
            finally { s.Release(); }
        }

        //  TurnReset
        [HttpPost]
        public IActionResult TurnReset([FromQuery] string gameId, [FromQuery] string color)
        {
            System.Threading.Semaphore s = new System.Threading.Semaphore(1, 1, "COPS"); s.WaitOne();
            try
            {
                if (gameId == null)
                    return BadRequest();
                MakeCertainGameExists(gameId);
                var board = VisualBoardStore.GameBoard(gameId + "SNAPSHOT");
                VisualBoardStore.KillBoard(gameId);
                var newboard = new Dictionary<string, string>();
                foreach (var item in board)
                    newboard.Add(item.Key, item.Value);

                VisualBoardStore.AddBoard(gameId, newboard); // overwrite it

                Response.Headers.Add("Access-Control-Allow-Origin", "*");
            return Ok();
            }
            finally { s.Release(); }
        }


        //  TurnReset
        [HttpPost]
        public IActionResult TurnConcluded([FromQuery] string gameId, [FromQuery] string color)
        {
            System.Threading.Semaphore s = new System.Threading.Semaphore(1, 1, "COPS"); s.WaitOne();
            try
            {
                if (gameId == null)
                    return BadRequest();
                MakeCertainGameExists(gameId);
                var board = VisualBoardStore.GameBoard(gameId);

                if (VisualBoardStore.ContainsGame(gameId + "SNAPSHOT"))
                {
                    var hintboard = new List<string>();
                    foreach (var item in VisualBoardStore.GameBoard(gameId + "SNAPSHOT"))
                    {
                        var key = item.Key;
                        if (item.Value != board[key])
                            hintboard.Add(key); // hint this spot globally as a clue
                    }
   //                 VisualBoardStore.StoreHints(hintboard);
                }


                // just store that last board state in case someone hits turn reset.
                if(VisualBoardStore.ContainsGame(gameId + "SNAPSHOT"))
                    VisualBoardStore.KillBoard(gameId + "SNAPSHOT"); // if any...
                var newboard = new Dictionary<string, string>();
                foreach (var item in board)
                    newboard.Add(item.Key, item.Value);
                VisualBoardStore.AddBoard(gameId + "SNAPSHOT", newboard);

                Response.Headers.Add("Access-Control-Allow-Origin", "*");
                return Ok();
            }
            finally { s.Release(); }
        }


        //  Get the board from the perspective of one selected piece
        [HttpGet]
        public IActionResult Selected([FromQuery] string gameId, [FromQuery] string loc, [FromQuery] string color)
        {
            System.Threading.Semaphore s = new System.Threading.Semaphore(1, 1, "COPS"); s.WaitOne();
            try
            {
                if (gameId == null)
                    return BadRequest();
                MakeCertainGameExists(gameId);
                var board = VisualBoardStore.GameBoard(gameId);

                Dictionary<string, string> boardHues = new Dictionary<string, string>();
                foreach (var pos in board.Keys)
                    if (pos == "n0_n0")
                        boardHues.Add(pos, "0,0,0,1.0"); // black center
                    else
                        boardHues.Add(pos, "128,128,128,0.9"); // gray by default

                HexC.Program.LightUpWillsBoard(board, boardHues, loc);
                VisualBoardStore.ReplaceHues(gameId, color, boardHues);

                string json = "";
                json = "[";

                    foreach (var spot in board)
                    {
                        json += "{\"loc\":\"" + spot.Key;
                        json += "\",\"tok\":\"" + spot.Value;
                        json += "\",\"hue\":\"" + boardHues[spot.Key];  // (spot.Key[0] == 'P' ? "0,255,0,0.7" : "255,0,0,0.7");

                        json += "\"},";
                    }
                    json = json.Substring(0, json.Length - 1);
                    json += "]";

                //Response.Headers.Add("Access-Control-Allow-Origin", "https://hexagonalchess.online");
                Response.Headers.Add("Access-Control-Allow-Origin", "*");
                return Ok(json);
            }
            finally { s.Release(); }
        }


        [HttpGet]
        public IActionResult Board([FromQuery] string gameId, [FromQuery] string color)
        {
        System.Threading.Semaphore s = new System.Threading.Semaphore(1, 1, "COPS"); s.WaitOne();
            try
            {
                if (null == gameId || color == null)
                    return BadRequest();
                MakeCertainGameExists(gameId);
                var board = VisualBoardStore.GameBoard(gameId);
                var hues = VisualBoardStore.Hues(gameId, color);
            //            var hues = VisualBoardStore.ReplaceHues(gameid, color);

                string json = "[";

                foreach (var spot in board)
                {
                    json += "{\"loc\":\"" + spot.Key;
                    json += "\",\"tok\":\"" + spot.Value;

                    string hue = "128,128,128,0.9";
                    if (spot.Key == "n0_n0")
                        hue = "0,0,0,1.0";

                    if (hues.ContainsKey(spot.Key))
                        hue = hues[spot.Key];



                    json += "\",\"hue\":\"" + hue;

                    json += "\"},";
                }

                json = json.Substring(0, json.Length - 1);
                json += "]";

                //Response.Headers.Add("Access-Control-Allow-Origin", "https://hexagonalchess.online");
                Response.Headers.Add("Access-Control-Allow-Origin", "*");
                return Ok(json);
            }
            finally { s.Release(); }
        }

        [HttpOptions]
        public IActionResult TurnReset()
        {
            Response.Headers.Add("Allow", "OPTIONS,GET,PUT,POST,PATCH");
            Response.Headers.Add("Access-Control-Allow-Methods", "GET,PUT,POST,DELETE,OPTIONS");
            Response.Headers.Add("Access-Control-Allow-Headers", "Content-Type,Authorization,Content-Length,X-Requested-With,Accept");
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            Response.Headers.Add("Content-Length", "0");

            return Ok();
        }

        [HttpOptions]
        public IActionResult TurnConcluded()
        {
            Response.Headers.Add("Allow", "OPTIONS,GET,PUT,POST,PATCH");
            Response.Headers.Add("Access-Control-Allow-Methods", "GET,PUT,POST,DELETE,OPTIONS");
            Response.Headers.Add("Access-Control-Allow-Headers", "Content-Type,Authorization,Content-Length,X-Requested-With,Accept");
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            Response.Headers.Add("Content-Length", "0");

            return Ok();
        }

        [HttpOptions]
        public IActionResult Board()
        {
            Response.Headers.Add("Allow", "OPTIONS,GET,PUT,POST,PATCH");
            Response.Headers.Add("Access-Control-Allow-Methods", "GET,PUT,POST,DELETE,OPTIONS");
            Response.Headers.Add("Access-Control-Allow-Headers", "Content-Type,Authorization,Content-Length,X-Requested-With,Accept");
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            Response.Headers.Add("Content-Length", "0");

            return Ok();
        }

        [HttpOptions]
        public IActionResult Pieces()
        {
            Response.Headers.Add("Allow", "OPTIONS,GET,PUT,POST,PATCH");
            Response.Headers.Add("Access-Control-Allow-Methods", "GET,PUT,POST,DELETE,OPTIONS");
            Response.Headers.Add("Access-Control-Allow-Headers", "Content-Type,Authorization,Content-Length,X-Requested-With,Accept");
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            Response.Headers.Add("Content-Length", "0");

            return Ok();
        }

        [HttpOptions]
        public IActionResult Selected()
        {
            Response.Headers.Add("Allow", "OPTIONS,GET,PUT,POST,PATCH");
            Response.Headers.Add("Access-Control-Allow-Methods", "GET,PUT,POST,DELETE,OPTIONS");
            Response.Headers.Add("Access-Control-Allow-Headers", "Content-Type,Authorization,Content-Length,X-Requested-With,Accept");
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            Response.Headers.Add("Content-Length", "0");

            return Ok();
        }
    }
}