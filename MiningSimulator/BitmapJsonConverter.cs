using Newtonsoft.Json;

namespace MiningSimulator {
    public class BitmapJsonConverter : JsonConverter {
        public override bool CanConvert(Type objectType) {
            return typeof(Image).IsAssignableFrom(objectType);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) {
            Bitmap bitmap = (Bitmap)value;
            // Assuming you have a method to get the resource name from the Bitmap
            string resourceName = GetResourceNameFromBitmap(bitmap);
            writer.WriteValue(resourceName);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
            string resourceName = (string)reader.Value;
            // Assuming you have a method to get the Bitmap from the resource name
            Bitmap bitmap = GetBitmapFromResourceName(resourceName);
            return bitmap;
        }
        public static class ResourceBitmaps {
            public static Dictionary<string, Bitmap> Bitmaps = new Dictionary<string, Bitmap>
            {
        { "empty_space", Properties.Resources.empty_space },
        { "dirt", Properties.Resources.dirt },
        { "light_rock", Properties.Resources.light_rock },
        { "dark_rock", Properties.Resources.dark_rock },
        { "solid_rock", Properties.Resources.solid_rock },
        { "d_t1", Properties.Resources.d_t1 },
        { "d_t2", Properties.Resources.d_t2 },
        { "d_t3", Properties.Resources.d_t3 },
        { "rd_t1", Properties.Resources.rd_t1 },
        { "rd_t2", Properties.Resources.rd_t2 },
        { "rd_t3", Properties.Resources.rd_t3 },
        { "rune_t1", Properties.Resources.rune_t1 },
        { "rune_t2", Properties.Resources.rune_t2 },
        { "rune_t3", Properties.Resources.rune_t3 },
        { "bow_t1", Properties.Resources.bow_t1 },
        { "bow_t2", Properties.Resources.bow_t2 },
        { "bow_t3", Properties.Resources.bow_t3 }};
        }

        public string GetResourceNameFromBitmap(Bitmap bitmap) {
            foreach (var pair in ResourceBitmaps.Bitmaps) {
                if (pair.Value == bitmap) {
                    return pair.Key;
                }
            }
            throw new ArgumentException("Bitmap not found in resources.");
        }

        public Bitmap GetBitmapFromResourceName(string resourceName) {
            if (ResourceBitmaps.Bitmaps.TryGetValue(resourceName, out Bitmap bitmap)) {
                return bitmap;
            }

            throw new ArgumentException("Resource name not found.");
        }
    }
}