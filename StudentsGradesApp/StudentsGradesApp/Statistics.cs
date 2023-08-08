namespace StudentsGradesApp
{
    public class Statistics
    {
        public float Min { get; set; }
        public float Max { get; set; }
        public float Sum { get; set; }
        public int Count { get; set; }

        public float Average
        {
            get
            {
                return this.Sum / this.Count;
            }
        }

        public char AwardLetter
        { get
            {
                switch (this.Average)
                {
                    case var average when average >= 4.75:
                        return 'T';
                    default:
                        return 'N';
                }
                    
            }
        }

        public Statistics()
        {
            this.Sum = 0;
            this.Count = 0;
            this.Max = float.MinValue;
            this.Min = float.MaxValue;
        }

        public void AddGrade(float grade)
        {
            this.Count++;
            this.Sum += grade;
            this.Min = Math.Min(this.Min, grade);
            this.Max = Math.Max(this.Max, grade);
        }
    }
}
