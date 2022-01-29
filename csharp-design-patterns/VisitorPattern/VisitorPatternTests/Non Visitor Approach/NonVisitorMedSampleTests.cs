using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace VisitorPatternTests
{
    public class NonVisitorMedSampleTests
    {
        [Test]
        public void TestNonVisitorApproach()
        {
            var samples = new List<IResult>() { new BloodSample(), new XRayImage() };

            var detectors = new List<IDetector>() { new CancerDetector(), new HivDetector() };
            var results = new List<AlertReport>();

            foreach (var sample in samples)
            {
                foreach (var detector in detectors)
                {
                    results.Add(detector.DetectFrom(sample));
                }
            }

        }
    }
}