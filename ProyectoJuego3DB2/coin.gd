extends Area3D

@export var goulToGive : int = 1
var rotateSpeed : float = 5.0

func _process(delta):
	rotate_y(rotateSpeed * delta)
	pass

func _on_body_entered(body):
	if body.name == "untitled":
		body.givegoul(goulToGive)
		queue_free()
		
