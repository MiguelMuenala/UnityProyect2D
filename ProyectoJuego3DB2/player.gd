extends CharacterBody3D


const SPEED = 5.0
const JUMP_VELOCITY = 6.0 #4.5

# Get the gravity from the project settings to be synced with RigidBody nodes.
var gravity = ProjectSettings.get_setting("physics/3d/default_gravity")
var lookat
var lastLookAtDireccion : Vector3

var gould: int = 0

@onready var sttackCast = $AtackRayCast
#var sttackCast = get_tree().get_node("AtackRayCast")

var curHp : int = 10
var maxHp : int = 3
var damage : int = 1
var attackRate : float = 0.3
var lastAttackTime : float = 0

@onready var ui = $CanvasLayer/UI


func _ready():
	lookat = get_tree().get_nodes_in_group("CameraController")[0].get_node("LookAt")
	ui.update_gold_text(gould)
	ui.update_health_bar(curHp, maxHp)

func _physics_process(delta):
	# Add the gravity.
	if not is_on_floor():
		velocity.y -= gravity * delta

	# Handle Jump.
	if Input.is_action_just_pressed("ui_accept") and is_on_floor():
		velocity.y = JUMP_VELOCITY
	# Get the input direction and handle the movement/deceleration.
	# As good practice, you should replace UI actions with custom gameplay actions.
	
	#look_at(get_tree().get_nodes_in_group("CameraController")[0].get_node("LookAt").global_position)
	
	#var input_dir = Input.get_vector("ui_left", "ui_right", "ui_up", "ui_down")
	var input_dir = Input.get_vector( "ui_OnClik_A", "ui_OnClik_D", "ui_OnClik_W", "ui_OnClik_S")
	var direction = (transform.basis * Vector3(input_dir.x, 0, input_dir.y)).normalized()
	if direction:
		var lerpDirecction = lerp(lastLookAtDireccion, Vector3(lookat.global_position.x, global_position.y, lookat.global_position.z), 1)
		look_at(Vector3(lerpDirecction.x, global_position.y, lerpDirecction.z))
		lastLookAtDireccion = lerpDirecction
		#look_at(Vector3(lookat.global_position.x, global_position.y, lookat.global_position.z))
		velocity.x = direction.x * SPEED
		velocity.z = direction.z * SPEED
	else:
		velocity.x = move_toward(velocity.x, 0, SPEED)
		velocity.z = move_toward(velocity.z, 0, SPEED)
		
	#if Input.is_action_just_released("ui_select"): ui_OnClik_A
	$AnimationTree.set("parameters/conditions/idlee", input_dir == Vector2.ZERO && is_on_floor() && Input.is_action_just_released("ui_select"))
		
	#else:
	$AnimationTree.set("parameters/conditions/runn", input_dir != Vector2.ZERO && is_on_floor() )
	$AnimationTree.set("parameters/conditions/falling", !is_on_floor())
	$AnimationTree.set("parameters/conditions/dancing", Input.is_action_just_pressed("ui_OnClik_f") && input_dir == Vector2.ZERO && is_on_floor())
	#$AnimationTree.set("parameters/conditions/puch", Input.is_action_just_pressed("ui_left_click") )
		
	move_and_slide()
	
	
	
func givegoul(goulToGive): #obtyener monedas
	gould += goulToGive
	ui.update_gold_text(gould)
	print(gould)
	
func take_damage(damage):
	curHp -= damage
	ui.update_health_bar(curHp, maxHp)
	print(curHp)
	if curHp <= 0:
		$AnimationTree.animation_finished
		$AnimationPlayer.play("death")
		die()
		
func die():
	await get_tree().create_timer(5).timeout
	get_tree().reload_current_scene()
		


func _process(delta):
	if Input.is_action_just_pressed("ui_left_click"):
		try_attack()
		
func  try_attack():
	if Time.get_ticks_msec() - lastAttackTime < attackRate * 1000:
		return
	lastAttackTime =  Time.get_ticks_msec()
	$WeaponHolder/WeaponAnimator.stop()
	$WeaponHolder/WeaponAnimator.play("creaftAttack")
	
	if sttackCast.is_colliding():
		if sttackCast.get_collider().has_method("take_damage"):
			sttackCast.get_collider().take_damage(damage)
