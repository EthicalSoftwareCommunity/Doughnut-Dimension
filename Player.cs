using Godot;
using System;

public class Player : KinematicBody
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    [Export] private NodePath joysticPath;
    private Joystic _joystic;
    private Vector3 speed = new (50,50,50);
    private Vector3 direction = new Vector3();
    private Vector3 _speed;
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        _joystic = GetNode<Joystic>(joysticPath);
    }

    public override void _PhysicsProcess(float delta)
    {
        var coll =   speed/5 *Transform.basis.z* delta* _joystic.GetButtonPosition().y;
        
        //RotateZ(Mathf.Deg2Rad(_joystic.GetButtonPosition().x/100));
        if (GetSlideCount() != 0)
        {
            coll = coll.Normalized();
            direction = coll - coll.Dot(GetSlideCollision(0).Normal) * GetSlideCollision(0).Normal;
           // LookAt(coll.Cross(GetSlideCollision(0).Normal),Vector3.Up);
            //RotateObjectLocal(new Vector3(0,0,1), GetSlideCollision(0).GetAngle(direction)-Mathf.Deg2Rad(90));s
            LookAtFromPosition(Translation,Translation+direction, GetSlideCollision(0).Normal);
            MoveAndSlide(direction);
            GD.Print("look");
            //RotateObjectLocal(Transform.basis.x.MoveToward(),coll.AngleTo(direction)/10);
        }
        else
        {
            MoveAndSlide(coll);
            //LookAtFromPosition(Translation,Translation+direction, Transform.basis.z);
        }
        

        //AddCentralForce(coll);
     
            /*var x = GetSlideCollision(0).Normal.x;
            var y = GetSlideCollision(0).Normal.y;
            Vector3 r = new Vector3(
                x * Mathf.Cos(Mathf.Deg2Rad(180)) - y * Mathf.Sin(Mathf.Deg2Rad(180)),
                y * Mathf.Cos(Mathf.Deg2Rad(180)) + x *Mathf.Sin(Mathf.Deg2Rad(180)),
                0);
            LookAt(r, Vector3.Up);*/
            
            /*//Rotate(Transform.basis.x.Normalized(), .Position.DirectionTo(Translation).AngleTo(Transform.basis.y)-Mathf.Deg2Rad(180));
            //LookAtFromPosition(GlobalTranslation,Transform.basis.z.DirectionTo(GlobalTranslation),Vector3.Up);
            MoveAndSlide(  speed/10 * Transform.basis.z.DirectionTo(Transform.basis.y) * _joystic.GetButtonPosition().y*delta);
            GD.Print(coll);
        }
        else
        {
            MoveAndSlide(coll);
        }*/

       
        //if(GetLastSlideCollision()!=null)
        //    Rotate(Transform.Orthonormalized().origin, Mathf.Deg2Rad(_joystic.GetButtonPosition().x/100));
        //Vector3 _speed = Transform.basis.z * -1  * delta;
        //AddCentralForce(new Vector3(1,0,0)*delta*speed);
    }
    /*private Vector3 UpdateDirectionPlayer() // Обновляет вектор движения игрока на основе нормали поверхности по которой он двигается
    {
        var normal = GetFloorNormal();
        var direction =  speed/10 * Vector3.Forward * _joystic.GetButtonPosition().y;;
        direction = direction.Normalized();
        return direction - direction.Dot(normal) * normal;
    }
 
    private void Move()
    {

    }
    //  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }*/
}
