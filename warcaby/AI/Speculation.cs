//using System;
//using System.CodeDom.Compiler;
//using System.Collections;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Checkers;

//namespace warcaby.Engine
//{
//    public class Speculation
//    {
//        private readonly Player _p1;
//        private readonly Player _p2;
//        private readonly Board _sourceBoard;
//        private readonly int _maxDeepLevel;
//        public List<SpeculationNode> speculationTree { get; }

//        public Speculation(Player p1, Player p2, Board sourceBoard, int max)
//        {
//            this._p1 = p1;
//            this._p2 = p2;
//            this._sourceBoard = sourceBoard;
//            this._maxDeepLevel = max;
//            this.speculationTree = new List<SpeculationNode>();
//            this.GenerateTree();
//        }

//        public List<SpeculationNode> GetTree()
//        {
//            return speculationTree;
//        }

//        public List<List<SpeculationNode>> GetLists()
//        {
//            TreeConverter<SpeculationNode> converter = new TreeConverter<SpeculationNode>(speculationTree);
//            List<List<SpeculationNode>> listOfList = converter.GetGeneratedLists();

//            foreach (List<SpeculationNode> list in listOfList)
//            {
//                foreach (SpeculationNode obj in list)
//                {
//                    obj.speculationChildren = null;
//                }
//            }

//            return listOfList;
//        }

//        private void GenerateTree(SpeculationNode node = null)
//        {
//            Player player;
//            Board board;
//            List<Move> availableMoves;
//            int deepLevel;

//            if (node == null)
//            {
//                board = _sourceBoard;
//                player = _p1;
//                deepLevel = 1;
//                availableMoves = GetAllAvailableMoves(_sourceBoard, player);
//            }

//            else
//            {
//                board = node.effect;
//                player = GetOposittePlayer(node.player);
//                deepLevel = node.deepLevel + 1;
//                availableMoves = GetAllAvailableMoves(node.effect, player);
//            }

//            foreach (Move move in availableMoves)
//            {
//                FightMove fm = move as FightMove;
//                Board effectOfMove = null;
//                SpeculationNode childrenNode;
//                List<Move> moves;

//                if (fm != null)
//                {
//                    foreach (List<FightMove> list in fm.possibleWaysToBeat)
//                    {
//                        effectOfMove = FightMove.Simulate(board, list);
//                        moves = Extension.ToMoves(list);
//                        childrenNode = new SpeculationNode(moves, effectOfMove, player, deepLevel);

//                        if (node != null)
//                            node.speculationChildren.Add(childrenNode);
//                        else
//                            speculationTree.Add(childrenNode);

//                        if (deepLevel < _maxDeepLevel)
//                            GenerateTree(childrenNode);
//                    }
//                }

//                else
//                {
//                    effectOfMove = move.Simulate(board);
//                    moves = new List<Move>();
//                    moves.Add(move);
//                    childrenNode = new SpeculationNode(moves, effectOfMove, player, deepLevel);

//                    if (node != null)
//                        node.speculationChildren.Add(childrenNode);
//                    else
//                        speculationTree.Add(childrenNode);

//                    if (deepLevel < _maxDeepLevel)
//                        GenerateTree(childrenNode);
//                }
//            }
//        }

//        private List<Move> GetAllAvailableMoves(Board board, Player player)
//        {
//            Scope scope = new Scope(board);
//            List<Move> availableMoves = scope.GetAvailableMoves(player);
//            return availableMoves;
//        }

//        private Player GetOposittePlayer(Player player)
//        {
//            if (player == _p1)
//                return _p2;
//            return _p1;
//        }
//    }
//}
