extends CharacterBody3D

#Variablers de enemigo
var curHp : int = 3
var maxHp : int = 3
var damage : int = 1
var gravity = ProjectSettings.get_setting("physics/3d/default_gravity")

var attackDist : float = 6.0
var attackRate : float = 1.0
var moveSpeed : float = 0.02

var vel : Vector3 = Vector3()

@onready var timer = get_node("Timer")
@onready var pla = get_tree().get_nodes_in_group("Player")[0]

func _ready():
	timer.wait_time = attackRate
	timer.start()

func _physics_process(delta):	
	if not is_on_floor():
		velocity.y -= gravity * delta

	
	var dist = transform.origin.distance_to(pla.transform.origin)
	print(dist)
	if dist < attackDist:
		print(attackDist)
		var dir = (pla.global_transform.origin - self.global_transform.origin).normalized()
		vel.x = dir.x * moveSpeed
		vel.y = 0
		vel.z = dir.z * moveSpeed
		translate(vel)
		
	move_and_slide()#> 
		#vel = move_and_slide(vel, Vector3.UP)
	#$AnimationTree.set("parameters/conditions/walkEnemy",  is_on_floor())
	

func _on_timer_timeout():
	if transform.origin.distance_to(pla.transform.origin) <= attackDist:
		pla.take_damage(damage)
		print(attackDist)
	pass # Replace with function body.
	
	
func take_damage(damage):
	curHp -= damage
	if curHp <= 0:
		die()
	
func die():
	queue_free()
	
