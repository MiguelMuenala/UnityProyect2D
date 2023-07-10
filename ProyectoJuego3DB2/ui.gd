extends Control

@onready var health = $HealthBar
@onready var goldt = $Label
# Called when the node enters the scene tree for the first time.

func  update_health_bar(curHp, maxHp):
	health.value = (100/maxHp)* curHp

func  update_gold_text(gold):
	goldt.text = "Gold: " + str(gold)


func _ready():
	pass # Replace with function body.


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	pass
