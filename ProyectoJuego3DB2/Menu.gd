extends Control


# Called when the node enters the scene tree for the first time.
func _ready():
	pass # Replace with function body. res://node_3d.tscn


# Called every frame. 'delta' is the elapsed time since the previous frame. 
func _process(delta):
	pass


func _on_play_pressed():
	get_tree().change_scene_to_file("res://node_3d.tscn")


func _on_quit_pressed():
	get_tree().quit()


func _on_history_pressed():
	get_tree().change_scene_to_file("res://intro.tscn")
