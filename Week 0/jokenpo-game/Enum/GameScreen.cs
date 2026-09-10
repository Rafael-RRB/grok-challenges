namespace JokenpoTerminal.Enum
{
    public enum GameScreen
    {
        Intro, // Sliding bg animation
        MainMenu, // Animated bg with menu options
        EnemyIntro, // Sorta like megaman or street fighter intro, with the enemy name and a "VS". Possibly two sliding: "VS" right to left, and enemy name left to right
        Battle, // Bobbing sprite
        MatchResult, // Move animation, moves selected, then result -- do we need a victory/defeat/draw screen?
        Gameover // Something like Earthbound's game over, with a sprite and light, which then fades from white > light gray > gray > dark gray > black
    }
}
