using UnityEngine;
using UnityEngine.Tilemaps;

namespace Platformer.Mechanics {
    public class ColoredObject : MonoBehaviour {
        public ObjectColor color;

        public void SetColor(ObjectColor color) {
            this.color = color;
            // Change tilemap color
            Tilemap tilemap = GetComponent<Tilemap>();
            Color newColor = tilemap.color;
            // Change color alpha to 1
            newColor.a = 1;
            switch (color)
            {
                case ObjectColor.Red:
                    newColor.r = 1;
                    newColor.g = 0;
                    newColor.b = 0;
                    break;
                case ObjectColor.Green:
                    newColor.r = 0;
                    newColor.g = 1;
                    newColor.b = 0;
                    break;
                default:
                    break;
            }
            tilemap.color = newColor;
        }

        public ObjectColor GetColor() {
            return color;
        }

        private void Start() {
            SetColor(color);
        }

        private void Update() {
            if(Input.GetButtonUp("ToggleColor")) {
                if(color == ObjectColor.Red) {
                    SetColor(ObjectColor.Green);
                } else {
                    SetColor(ObjectColor.Red);
                }
            }

            // If color is red, enable collision
            // If color is green, disable collision
            TilemapCollider2D tilemapCollider2D = GetComponent<TilemapCollider2D>();
            if(color == ObjectColor.Red) {
                tilemapCollider2D.enabled = true;
            } else {
                tilemapCollider2D.enabled = false;
            }
        }

        public enum ObjectColor {
            Red,
            Green
        }
    }
}