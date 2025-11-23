using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using UnityEngine;
using Random = UnityEngine.Random;


namespace Yrr.Utils
{
    /// Version 0.8.3
    public static class Extensions
    {
        public static void ClearChildren(this Transform transform)
        {
            var count = transform.childCount;
            if (count <= 0) return;
            for (var i = count - 1; i >= 0; i--)
            {
                var child = transform.GetChild(i);
                child.SetParent(null);
                GameObject.Destroy(child.gameObject);
            }
        }

        public static void ChangeLayerRecursively(this GameObject gameObject, int layer)
        {
            gameObject.layer = layer;
            foreach (Transform child in gameObject.transform)
            {
                ChangeLayerRecursively(child.gameObject, layer);
            }
        }

        #region Vectors  
        public static Vector3 GetRandomCoordinatesAroundPointZX(this Vector3 originalPoint, float radius,
                bool pointOnRadiusLine = false)
        {
            float angle = Random.Range(0, 360);
            var lenght = pointOnRadiusLine ? radius :
                (Random.Range(0, radius));

            var x = Mathf.Cos(angle * Mathf.Deg2Rad) * lenght;
            var y = Mathf.Sin(angle * Mathf.Deg2Rad) * lenght;


            var result = new Vector3(originalPoint.x + x, originalPoint.y, originalPoint.z + y);
            return result;
        }

        public static Vector3 GetRandomCoordinatesAroundPointXY(this Vector3 originalPoint, float radius,
               bool pointOnRadiusLine = false)
        {
            float angle = Random.Range(0, 360);
            var lenght = pointOnRadiusLine ? radius :
                (Random.Range(0, radius));

            var x = Mathf.Cos(angle * Mathf.Deg2Rad) * lenght;
            var y = Mathf.Sin(angle * Mathf.Deg2Rad) * lenght;


            var result = new Vector3(originalPoint.x + x, originalPoint.y + y, originalPoint.z);
            return result;
        }

        public static Vector2 ToVector2XZ(this Vector3 vector)
        {
            return new Vector2(vector.x, vector.z);
        }

        public static Vector2 ToVector2XY(this Vector3 vector)
        {
            return new Vector2(vector.x, vector.y);
        }

        public static Vector3 InvertYZ(this Vector3 vector)
        {
            return new Vector3(vector.x, vector.z, vector.y);
        }

        public static Vector3 ToVector3(this Vector2 vector, float y = 0)
        {
            return new Vector3(vector.x, y, vector.y);
        }

        #endregion


        #region Angles
        public static float GetAngleDirectionY(Vector3 fromPosition, Vector3 toPosition)
        {
            Vector3 direction = toPosition - fromPosition;
            float angleRad = Mathf.Atan2(direction.x, direction.z);
            float angleDeg = angleRad * Mathf.Rad2Deg;
            return NormalizeAngle(angleDeg);
        }

        public static float GetAngleDirectionY(Vector3 direction)
        {
            float angleRad = Mathf.Atan2(direction.x, direction.z);
            float angleDeg = angleRad * Mathf.Rad2Deg;
            return NormalizeAngle(angleDeg);
        }

        public static float GetAngleDirectionY(Vector2 direction)
        {
            float angleRad = Mathf.Atan2(direction.x, direction.y);
            float angleDeg = angleRad * Mathf.Rad2Deg;
            return NormalizeAngle(angleDeg);
        }

        public static float GetMinAngledDelta(float angle1, float angle2)
        {
            float diff = Mathf.Abs(angle1 - angle2);
            return Mathf.Min(diff, 360 - diff);
        }

        public static float NormalizeAngle(float angle)
        {
            while (angle >= 360f) angle -= 360f;
            while (angle < 0f) angle += 360f;
            return angle;
        }

        public static float MoveTowardsAngle(this float currentAngle, float targetAngle, float maxDeltaRotation)
        {
            var diff = Mathf.DeltaAngle(currentAngle, targetAngle);
            var move = Mathf.Clamp(diff, -maxDeltaRotation, maxDeltaRotation);
            return NormalizeAngle(currentAngle + move);
        }
        #endregion


        #region GetRandom

        public static float GetRandomValue(this Vector2 vector)
        {
            return Random.Range(vector.x, vector.y);
        }

        public static T GetRandomItem<T>(this T[] list)
        {
            return list.Length < 1 ? default : list[Random.Range(0, list.Length)];
        }

        public static T GetRandomItem<T>(this IEnumerable<T> list)
        {
            var enumerable = list as T[] ?? list.ToArray();
            return enumerable.Any() ? enumerable.ElementAt(Random.Range(0, enumerable.Length)) : default;
        }

        public static int GetRandomIndex<T>(this IEnumerable<T> list)
        {
            return Random.Range(0, list.Count());
        }

        #endregion


        #region Collections
        public static void Shuffle<T>(this IList<T> list)
        {
            var n = list.Count;
            while (n > 1)
            {
                n--;
                var k = Random.Range(0, n);
                list.Swap(k, n);
            }
        }

        public static void Swap<T>(this IList<T> list, int indexA, int indexB)
        {
            (list[indexA], list[indexB]) = (list[indexB], list[indexA]);
        }

        public static void SwapWith<T>(this LinkedListNode<T> first, LinkedListNode<T> second)
        {
            var tmp = first.Value;
            first.Value = second.Value;
            second.Value = tmp;
        }

        public static T FindMin<T, TComp>(this IEnumerable<T> enumerable, Func<T, TComp> selector)
            where TComp : IComparable<TComp>
        {
            return Find(enumerable, selector, true);
        }

        public static T FindMax<T, TComp>(this IEnumerable<T> enumerable, Func<T, TComp> selector)
            where TComp : IComparable<TComp>
        {
            return Find(enumerable, selector, false);
        }

        private static T Find<T, TComp>(IEnumerable<T> enumerable, Func<T, TComp> selector, bool selectMin) where TComp : IComparable<TComp>
        {
            if (enumerable == null)
                return default;

            var first = true;
            T selected = default(T);
            TComp selectedComp = default(TComp);

            foreach (T current in enumerable)
            {
                TComp comp = selector(current);
                if (first)
                {
                    first = false;
                    selected = current;
                    selectedComp = comp;
                    continue;
                }

                int res = selectMin
                  ? comp.CompareTo(selectedComp)
                  : selectedComp.CompareTo(comp);

                if (res < 0)
                {
                    selected = current;
                    selectedComp = comp;
                }
            }

            return selected;
        }
        #endregion


        #region Strings

        public static string ToIntString(this float value)
        {
            return ((int)value).ToString();
        }

        public static string ToDotString(this float value)
        {
            var str = value.ToString(CultureInfo.InvariantCulture);
            return str.Replace(",", ".");
        }

        public static string ToShortMoneyString(this int value)
        {
            return ((ulong)value).ToShortMoneyString();
        }

        private static string[] _moneyPrefix = { string.Empty, "K", "M", "B", "T", "Q", "E", "Z" };

        public static string ToShortMoneyString(this float value)
        {
            return ((ulong)value).ToShortMoneyString();
        }

        public static string ToShortMoneyString(this ulong value)
        {
            if (value == 0) return "0";
            var absolute = Mathf.Abs(value);
            int add;
            if (absolute < 1)
            {
                add = (int)Mathf.Floor(Mathf.Floor(Mathf.Log10(absolute)) / 3);
            }
            else
            {
                add = (int)(Mathf.Floor(Mathf.Log10(absolute)) / 3);
            }

            var shortNumber = value / Mathf.Pow(10, add * 3);

            shortNumber *= 100;
            shortNumber = Mathf.Floor(shortNumber);
            shortNumber /= 100;

            if (shortNumber > 100f)
                return $"{(int)shortNumber}{_moneyPrefix[add]}";
            else if (shortNumber > 10f)
                return $"{shortNumber:0.#}{_moneyPrefix[add]}";
            else
                return $"{shortNumber:0.##}{_moneyPrefix[add]}";
        }

        public static string ToShortMoneyString(this double value)
        {
            return ((ulong)value).ToShortMoneyString();
        }

        public static ulong ToRounded(this ulong value)
        {
            if (value < 1000) return value;

            if (value < 10_000)
            {
                var shortVal = value / 10f;
                var rounded = Mathf.Round(shortVal);
                return (ulong)(rounded * 10f);
            }

            if (value < 100_000)
            {
                var shortVal = value / 100f;
                var rounded = Mathf.Round(shortVal);
                return (ulong)(rounded * 100f);
            }

            if (value < 1_000_000)
            {
                var shortVal = value / 1000f;
                var rounded = Mathf.Round(shortVal);
                return (ulong)(rounded * 1000f);
            }

            if (value < 1_000_000_000)
            {
                var shortVal = value / 100000f;
                var rounded = Mathf.Round(shortVal);
                return (ulong)(rounded * 100000f);
            }

            var shortVal1 = value / 1000000f;
            var rounded1 = Mathf.Round(shortVal1);
            return (ulong)(rounded1 * 1000000f);
        }

        public static string ToShortTimeString(this float timeValue)
        {
            var time = (int)timeValue + 1;

            var seconds = time % 60f;
            var minutes = time / 60;
            var hours = minutes / 60;
            minutes = minutes % 60;

            if (hours > 0) return hours.ToString("00") + "h ";
            if (minutes > 0) return minutes.ToString("00") + "m ";
            return seconds.ToString("00") + "s";
        }

        public static string ToTimeString(this float timeValue)
        {
            var time = (int)timeValue + 1;

            var seconds = time % 60f;
            var minutes = time / 60;
            var hours = minutes / 60;
            minutes = minutes % 60;

            var sb = new StringBuilder();
            if (hours > 0)
            {
                sb.Append(hours.ToString("00"));
                sb.Append(":");
            }
            sb.Append(minutes.ToString("00"));
            sb.Append(":");
            sb.Append(seconds.ToString("00"));

            return sb.ToString();
        }

        public static string ToLongTimeString(this float timeValue)
        {
            var time = (int)timeValue + 1;

            var seconds = time % 60f;
            var minutes = time / 60;
            var hours = minutes / 60;
            minutes = minutes % 60;

            var sb = new StringBuilder();

            sb.Append(hours.ToString("00"));
            sb.Append(":");
            sb.Append(minutes.ToString("00"));
            sb.Append(":");
            sb.Append(seconds.ToString("00"));

            return sb.ToString();
        }
        #endregion
    }
}