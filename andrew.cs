using Robocode.TankRoyale.BotApi;
using Robocode.TankRoyale.BotApi.Events;
using Robocode.TankRoyale.BotApi.Graphics;

public class SaucyTankBot : Bot
{
    static void Main(string[] args)
    {
        new SaucyTankBot().Start();
    }

    public override void Run()
    {
        BodyColor = Color.Gold;
        GunColor = Color.Gold;
        RadarColor = Color.Gold;
        BulletColor = Color.Gold;


        while (IsRunning)
        {
            Back(250);
            TurnGunRight(360);
            Forward(300);
            TurnGunRight(360);
        }
    }

    public override void OnScannedBot(ScannedBotEvent evt)
    {
        var distance = DistanceTo(evt.X, evt.Y);
        SmartFire(distance);
    }

    // We were hit by a bullet -> turn perpendicular to the bullet
    public override void OnHitByBullet(HitByBulletEvent evt)
    {
        // Calculate the bearing to the direction of the bullet
        double bearing = CalcBearing(evt.Bullet.Direction);

        // Turn 90 degrees to the bullet direction based on the bearing
        TurnLeft(90 - bearing);
        Forward(200);
    }

    public override void OnHitWall(HitWallEvent evt)
    {
        Back(20);
        TurnRight(90);
        Forward(40);
    }

    private void SmartFire(double distance)
    {
        if (distance > 200 || Energy < 15)
            Fire(1);
        else if (distance > 50)
            Fire(2);
        else
            Fire(3);
    }
}
