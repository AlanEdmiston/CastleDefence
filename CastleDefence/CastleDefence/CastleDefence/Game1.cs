using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace CastleDefence
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        #region private variables

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Vector2 castlePosition = new Vector2 (0, 0);
        Vector2 soldierPosition = new Vector2 (0, 0);
        Vector2 mousePositionStringVectorX = new Vector2(50, 50);
        Vector2 mousePositionStringVectorY = new Vector2(100, 50);
        Vector2 selectorVector = new Vector2(-150,-150);
        Rectangle selectorRect;
        Vector2 moneyVector = new Vector2(840, 560);
        Vector2 mouseNodeStringVector = new Vector2 (50,75);
        Vector2 currentBuildVector = new Vector2(0, 0);
        Vector2 peasantNumberStringVector = new Vector2(50, 100);

        Texture2D CastleTexture;
        Texture2D SoldierTexture;
        Texture2D ArcherTexture;
        Texture2D Archer2Texture;
        Texture2D CatapultTexture;
        Texture2D Catapult2Texture;
        Texture2D KingTexture;
        Texture2D KnightTexture;
        Texture2D peasantTexture;
        Texture2D Peasant2Texture;
        Texture2D RamTexture;
        Texture2D Soldier2Texture;
        Texture2D TurtleTexture;
        Texture2D DisplayTexture;
        Texture2D selector;
        Texture2D archerTowerTexture;

        Vector2 spawnPoint;
        Random rand;
        Rectangle rect;
        SpriteFont font1;

        MouseState oldMs;

        int startPeasantHealth = 15;
        int startSoldierHealth = 40;
        int startKnightHealth = 120;
        int startArcherHealth = 30;
        int startCatalpultHealth = 80;
        int startRamHealth = 50;
        int startTurtleHealth = 1000;
        int startKingHealth = 600;
        int peasantValue = 1;
        int soldierValue = 3;
        int knightValue = 20;
        int archerValue = 5;
        int catapultValue = 30;
        int ramValue = 15;
        int turtleValue = 50;
        int kingValue = 120;
        
        int peasantNumber = 0;
        int soldierNumber = 0;
        int knightNumber = 0;
        int archerNumber = 0;
        int catapultNumber = 0;
        int ramNumber = 0;
        int turtleNumber = 0;
        int kingNumber = 0;

        int levelValue = 10;
        int levelCurrentValue = 10;
        int waveNumber = 1;
        bool isWaveFinished = false;
        int money = 75;

        double theta = 0.0;

        Vector2 nodePositon;
        Vector2 mouseNodePosition;

        string mousePositionStringX;
        string mousePositionStringY;
        string moneyString;
        string mouseNodeString;
        string peasantNumberString;

        bool isWallSelected = false;
        bool isArcherTowerSelected = false;
        bool isFireTowerSelected = false;
        bool isMirrorTowerSelected = false;
        bool isCannonTowerSelected = false;
        bool isTrapSelected = false;
        bool isMagicTowerSelected = false;
        bool isCatapultTowerSelected = false;

        bool buildTower = false;

        Vector2 mousePosition = new Vector2(0,0);

        MouseState ms;

        List<Enemies> allEnemies = new List<Enemies>();
        List<Projectile> allProjectiles = new List<Projectile>();
        List<Towers> walls = new List<Towers>();
        List<Towers> archerTowers = new List<Towers>();
        List<Towers> fireTowers = new List<Towers>();
        List<Towers> mirrorTowers = new List<Towers>();
        List<Towers> cannonTowers = new List<Towers>();
        List<Towers> traps = new List<Towers>();
        List<Towers> magicTowers = new List<Towers>();
        List<Towers> catapultTowers = new List<Towers>();

        #endregion

        #region lifecycle

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            
            //this.graphics.IsFullScreen = true;
            this.IsMouseVisible = true;
            
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
            
        }

        #endregion

        #region game overrides

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>s
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            
            rect = new Rectangle(GraphicsDevice.Viewport.Height,0,
                                 GraphicsDevice.Viewport.Width-GraphicsDevice.Viewport.Height, GraphicsDevice.Viewport.Height);
            spriteBatch = new SpriteBatch(GraphicsDevice);
            CastleTexture = this.Content.Load<Texture2D>("Castle");
            ArcherTexture = this.Content.Load<Texture2D>("Archer");
            Archer2Texture = this.Content.Load<Texture2D>("Archer2");
            CatapultTexture = this.Content.Load<Texture2D>("Catapult");
            Catapult2Texture = this.Content.Load<Texture2D>("Catapult2");
            KingTexture = this.Content.Load<Texture2D>("king");
            KnightTexture = this.Content.Load<Texture2D>("knight");
            peasantTexture = this.Content.Load<Texture2D>("peasant");
            Peasant2Texture = this.Content.Load<Texture2D>("peasant2");
            RamTexture = this.Content.Load<Texture2D>("ram");
            SoldierTexture = this.Content.Load<Texture2D>("soldier");
            Soldier2Texture = this.Content.Load<Texture2D>("soldier2");
            TurtleTexture = this.Content.Load<Texture2D>("turtle");
            DisplayTexture = this.Content.Load<Texture2D>("towerDefenseDisplay");
            font1 = this.Content.Load<SpriteFont>("SpriteFont1");
            selector = this.Content.Load<Texture2D>("select");
            archerTowerTexture = this.Content.Load<Texture2D>("archerTower");

            castlePosition.X = (GraphicsDevice.Viewport.Height - CastleTexture.Width) / 2;
            castlePosition.Y = (GraphicsDevice.Viewport.Height - CastleTexture.Height) / 2;
            
            // Spawn Enemies
            rand = new Random();
            while (levelCurrentValue > 0)
            {
                int recruiter = rand.Next(1, 8);

                switch (recruiter)
                {
                    case Enemies.PEASANT:
                        if (levelCurrentValue >= peasantValue)
                        {
                            levelCurrentValue = levelCurrentValue - peasantValue;
                            allEnemies.Add(SpawnEnemy(Enemies.PEASANT, peasantTexture, Peasant2Texture));
                        }
                        break;
                    case Enemies.SOLDIER:
                        if (levelCurrentValue >= soldierValue)
                        {
                            levelCurrentValue = levelCurrentValue - soldierValue;
                            allEnemies.Add(SpawnEnemy(Enemies.SOLDIER, SoldierTexture));
                        }
                        break;
                    case Enemies.ARCHER:
                        if (levelCurrentValue >= archerValue)
                        {
                            levelCurrentValue = levelCurrentValue - archerValue;
                            allEnemies.Add(SpawnEnemy(Enemies.ARCHER, ArcherTexture));
                        }
                        break;
                    case Enemies.KNIGHT:
                        if (levelCurrentValue >= knightValue)
                        {
                            levelCurrentValue = levelCurrentValue - knightValue;
                            allEnemies.Add(SpawnEnemy(Enemies.KNIGHT, KingTexture)); 
                        }
                        break;
                    case Enemies.RAM:
                        if (levelCurrentValue >= ramValue)
                        {
                            levelCurrentValue = levelCurrentValue - ramValue;
                            allEnemies.Add(SpawnEnemy(Enemies.RAM, RamTexture));
                        }
                        break;
                    case Enemies.TURTLE:
                        if (levelCurrentValue >= turtleValue)
                        {
                            levelCurrentValue = levelCurrentValue - turtleValue;
                            allEnemies.Add(SpawnEnemy(Enemies.TURTLE, TurtleTexture));
                        }
                        break;
                    case Enemies.CATAPULT:
                        if (levelCurrentValue >= catapultValue)
                        {
                            levelCurrentValue = levelCurrentValue - catapultNumber;
                            allEnemies.Add(SpawnEnemy(Enemies.CATAPULT, CatapultTexture));
                        }
                        break;
                    case Enemies.KING:
                        if (levelCurrentValue >= kingValue)
                        {
                            levelCurrentValue = levelCurrentValue - kingValue;
                            allEnemies.Add(SpawnEnemy(Enemies.KING, KingTexture));
                        }
                        break;
                    default:
                        break;

                }
            }  

           
            
            // TODO: use this.Content to load your game content here
        }


        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            
            // Allows the game to exit
            KeyboardState keys = Keyboard.GetState();
            if (keys.IsKeyDown(Keys.Escape))
            {
                Exit();
            }
            ms = Mouse.GetState();

            mousePosition.X = ms.X;
            mousePosition.Y = ms.Y;
            mousePositionStringX = mousePosition.X.ToString();
            mousePositionStringY = mousePosition.Y.ToString();

            peasantNumberString = peasantNumber.ToString();

            if (mousePosition.X > 750 && mousePosition.X < 917 && mousePosition.Y > 24 && 
                mousePosition.Y < 87 && ms.LeftButton == ButtonState.Pressed && money > Towers.wallCost)
            {
                isWallSelected = true;
                isArcherTowerSelected = false;
                isFireTowerSelected = false;
                isMirrorTowerSelected = false;
                isCannonTowerSelected = false;
                isTrapSelected = false;
                isMagicTowerSelected = false;
                isCatapultTowerSelected = false;
                selectorVector = new Vector2(750, 24);
            }

            if (mousePosition.X > 1035 && mousePosition.X < 1208 && mousePosition.Y > 21 &&
                mousePosition.Y < 89 && ms.LeftButton == ButtonState.Pressed && money > Towers.archerTowerCost)
            {
                isWallSelected = false;
                isArcherTowerSelected = true;
                isFireTowerSelected = false;
                isMirrorTowerSelected = false;
                isCannonTowerSelected = false;
                isTrapSelected = false;
                isMagicTowerSelected = false;
                isCatapultTowerSelected = false;
                selectorVector = new Vector2(690, 17);
            }

            if (mousePosition.X > 501 && mousePosition.X < 607 && mousePosition.Y > 79 &&
                mousePosition.Y < 119 && ms.LeftButton == ButtonState.Pressed && money > Towers.fireTowerCost)
            {
                isWallSelected = false;
                isArcherTowerSelected = false;
                isFireTowerSelected = true;
                isMirrorTowerSelected = false;
                isCannonTowerSelected = false;
                isTrapSelected = false;
                isMagicTowerSelected = false;
                isCatapultTowerSelected = false;
                selectorVector = new Vector2(501, 79);
            }

            if (mousePosition.X > 690 && mousePosition.X < 798 && mousePosition.Y > 79 &&
                mousePosition.Y < 119 && ms.LeftButton == ButtonState.Pressed && money > Towers.mirrorTowerCost)
            {
                isWallSelected = false;
                isArcherTowerSelected = false;
                isFireTowerSelected = false;
                isMirrorTowerSelected = true;
                isCannonTowerSelected = false;
                isTrapSelected = false;
                isMagicTowerSelected = false;
                isCatapultTowerSelected = false;
                selectorVector = new Vector2(690, 79);
            }

            if (mousePosition.X > 501 && mousePosition.X < 607 && mousePosition.Y > 140 &&
                mousePosition.Y < 180 && ms.LeftButton == ButtonState.Pressed && money>200)
            {
                isWallSelected = false  ;
                isArcherTowerSelected = false;
                isFireTowerSelected = false;
                isMirrorTowerSelected = false;
                isCannonTowerSelected = true;
                isTrapSelected = false;
                isMagicTowerSelected = false;
                isCatapultTowerSelected = false;
                selectorVector = new Vector2(501, 140);
            }

            if (mousePosition.X > 690 && mousePosition.X < 798 && mousePosition.Y > 140 &&
                mousePosition.Y < 180 && ms.LeftButton == ButtonState.Pressed && money > Towers.trapTowerCost)
            {
                isWallSelected = false;
                isArcherTowerSelected = false;
                isFireTowerSelected = false;
                isMirrorTowerSelected = false;
                isCannonTowerSelected = false;
                isTrapSelected = true;
                isMagicTowerSelected = false;
                isCatapultTowerSelected = false;
                selectorVector = new Vector2(690, 140);
            }

            if (mousePosition.X > 501 && mousePosition.X < 607 && mousePosition.Y > 200 &&
                mousePosition.Y < 240 && ms.LeftButton == ButtonState.Pressed && money > Towers.magicTowerCost)
            {
                isWallSelected = false;
                isArcherTowerSelected = false;
                isFireTowerSelected = false;
                isMirrorTowerSelected = false;
                isCannonTowerSelected = false;
                isTrapSelected = false;
                isMagicTowerSelected = true;
                isCatapultTowerSelected = false;
                selectorVector = new Vector2(501, 200);
            }

            if (mousePosition.X > 690 && mousePosition.X < 798 && mousePosition.Y > 200 &&
                mousePosition.Y < 240 && ms.LeftButton == ButtonState.Pressed && money > Towers.catapultTowerCost)
            {
                isWallSelected = false;
                isArcherTowerSelected = false;
                isFireTowerSelected = false;
                isMirrorTowerSelected = false;
                isCannonTowerSelected = false;
                isTrapSelected = false;
                isMagicTowerSelected = false;
                isCatapultTowerSelected = true;
                selectorVector = new Vector2(690, 200);
            }
            if (mousePosition.X < GraphicsDevice.Viewport.Height && mousePosition.X > 0
            && mousePosition.Y < GraphicsDevice.Viewport.Height && mousePosition.Y > 0)
            {
                mouseNodePosition.X = (int)Math.Floor(mousePosition.X / 24);
                mouseNodePosition.Y = (int)Math.Floor(mousePosition.Y / 24);
            }
            else
            {
                mouseNodePosition.X = 0;
                mouseNodePosition.Y = 0;
            }

            foreach (Enemies soldier in allEnemies)
            {
                nodePositon.X = (int)Math.Ceiling(mousePosition.X % 24);
                nodePositon.Y = (int)Math.Floor(mousePosition.Y % 24);
            }
            moneyString = money.ToString();
            mouseNodeString = mouseNodePosition.ToString();
            if (mousePosition.X < GraphicsDevice.Viewport.Height)
            {
                    currentBuildVector.X = (mouseNodePosition.X) * 24;
                    currentBuildVector.Y = (mouseNodePosition.Y) * 24;
            }
            if (isArcherTowerSelected == true && ms.LeftButton == ButtonState.Pressed && money >= 15
                && mousePosition.X < GraphicsDevice.Viewport.Height && oldMs.LeftButton == ButtonState.Released)
            {
                
                Towers archerTower = new Towers();

                archerTower.X = currentBuildVector.X;
                archerTower.Y = currentBuildVector.Y;

                archerTowers.Add(archerTower);

                money -= 15;
                
            }
            if (isWallSelected == true && ms.LeftButton == ButtonState.Pressed && money > 5
                && mousePosition.X < GraphicsDevice.Viewport.Height && oldMs.LeftButton == ButtonState.Released)
            {

                Towers wall = new Towers();

                wall.X = currentBuildVector.X;
                wall.Y = currentBuildVector.Y;

                walls.Add(wall);

                money = money - 5;

            }
            oldMs = ms;

            UpdateTowers();
            MoveProjectiles();

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            selectorRect = new Rectangle((int)selectorVector.X, (int)selectorVector.Y, 165, 63);
            GraphicsDevice.Clear(Color.Green);
            Color Transparant = new Color(0, 0, 0, 200);
            spriteBatch.Begin();
            spriteBatch.Draw(CastleTexture, castlePosition, Color.White);
            spriteBatch.Draw(DisplayTexture, rect, Color.White);
            spriteBatch.Draw(selector, selectorRect, Transparant);
            spriteBatch.DrawString(font1, mousePositionStringX, mousePositionStringVectorX, Color.Black);
            spriteBatch.DrawString(font1, mousePositionStringY, mousePositionStringVectorY, Color.Black);
            spriteBatch.DrawString(font1, moneyString, moneyVector, Color.Black);
            spriteBatch.DrawString(font1, mouseNodeString, mouseNodeStringVector,Color.Black);
            spriteBatch.DrawString(font1, peasantNumberString, peasantNumberStringVector, Color.Black);
            Color invisible = new Color(255,255,255,0);
            foreach (Towers archerTower in archerTowers)
            {
                spriteBatch.Draw(archerTowerTexture, archerTower.towerPosition, Color.White);
            }

            foreach (var enemy in allEnemies)
            {
                spriteBatch.Draw(enemy.Texture, enemy.position, Color.White);
            }
            foreach (Projectile projectile in allProjectiles)
            {
                spriteBatch.Draw(projectile.Texture, projectile.Position, Color.White);
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
        #endregion

        #region private helper method

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private Vector2 SpawnPoint()
        {
            Vector2 spawnedPoint = new Vector2();

            int spawner = rand.Next(1, 80);

            if (spawner <= 20)
            {
                spawnedPoint.Y = 0;
                spawnedPoint.X = spawner * 24;
            }

            if (spawner <= 40 && spawner > 20)
            {
                spawnedPoint.X = GraphicsDevice.Viewport.Height - 24;
                spawnedPoint.Y = (spawner - 20) * 24;
            }

            if (spawner <= 60 && spawner > 40)
            {
                spawnedPoint.X = (spawner - 40) * 24;
                spawnedPoint.Y = GraphicsDevice.Viewport.Height - 24;
            }

            if (spawner >= 60)
            {
                spawnedPoint.X = 0;
                spawnedPoint.Y = (spawner - 60) * 24;
            }

            return spawnedPoint;
        }

        private Enemies SpawnEnemy(int enemyType, Texture2D texture, Texture2D texture2)
        {
            var spawnPoint = SpawnPoint();
            Enemies enemy = new Enemies(enemyType, texture);
            enemy.X = spawnPoint.X;
            enemy.Y = spawnPoint.Y;
            return enemy;
        }

        private Enemies SpawnEnemy(int enemyType, Texture2D texture)
        {
            var spawnPoint = SpawnPoint();
            Enemies enemy = new Enemies(enemyType, texture);
            enemy.X = spawnPoint.X;
            enemy.Y = spawnPoint.Y;
            return enemy;

        }

        /// <summary>
        /// initialises projectiles 
        /// </summary>
        private void UpdateTowers()
        {
            //shoot at all enemies in range of towers
            foreach (Towers archerTower in archerTowers)
            {
                if (!archerTower.IsReloading)
                {
                    foreach (var enemy in allEnemies)
                    {
                        if (archerTower.IsInRange(enemy.position))
                        {
                            Projectile projectile = archerTower.Shoot(enemy.position, this.Content);
                            allProjectiles.Add(projectile);
                            break;
                        }
                    }
                }
            }
        }

         /// <summary>
        /// Updates position of projectiles in range of towers
        /// </summary>
        private void MoveProjectiles()
        {

            foreach (Projectile projectile in allProjectiles)
            {
                projectile.Move();
            }
            
        }
        #endregion

    }
}
