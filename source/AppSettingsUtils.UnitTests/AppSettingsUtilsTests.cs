using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Configuration.Fakes;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using FluentAssertions;
using Microsoft.QualityTools.Testing.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AppSettingsUtils.UnitTests
{
    /// <summary>
    ///     Summary description for AppSettingsUtilsTests
    /// </summary>
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class AppSettingsUtilsTests
    {
        private const string keyName = "foo";

        [TestMethod]
        public void TestGetString()
        {
            // Arrange
            const string expectedResult = "bar";

            using (ShimsContext.Create())
            {
                ShimConfigurationManager.AppSettingsGet = () =>
                                                          {
                                                              var values = new NameValueCollection();
                                                              values.Add(keyName, expectedResult);

                                                              return values;
                                                          };
                // Act
                var actualResult = AppSettingsUtil.GetString(keyName);

                // Assert
                actualResult.Should().Be(expectedResult);
            }
        }

        [TestMethod]
        public void TestGetStringWithDefault1()
        {
            // Arrange
            const string defaultValue = "default";
            const string expectedResult = "bar";

            using (ShimsContext.Create())
            {
                ShimConfigurationManager.AppSettingsGet = () =>
                                                          {
                                                              var values = new NameValueCollection();
                                                              values.Add(keyName, expectedResult);

                                                              return values;
                                                          };
                // Act
                var actualResult = AppSettingsUtil.GetString(keyName, defaultValue);

                // Assert
                actualResult.Should().Be(expectedResult);
            }
        }

        [TestMethod]
        public void TestGetStringWithDefault2()
        {
            // Arrange
            const string expectedResult = "default";

            using (ShimsContext.Create())
            {
                ShimConfigurationManager.AppSettingsGet = () =>
                                                          {
                                                              var values = new NameValueCollection();

                                                              return values;
                                                          };
                // Act
                var actualResult = AppSettingsUtil.GetString(keyName, expectedResult);

                // Assert
                actualResult.Should().Be(expectedResult);
            }
        }

        [TestMethod]
        public void TestGetStringWithoutDefault()
        {
            // Arrange
            using (ShimsContext.Create())
            {
                ShimConfigurationManager.AppSettingsGet = () =>
                                                          {
                                                              var values = new NameValueCollection();

                                                              return values;
                                                          };

                // Act
                Action act = () => AppSettingsUtil.GetString(keyName);

                // Assert
                act.ShouldThrow<ConfigurationErrorsException>();
            }
        }

        [TestMethod]
        public void TestGetDoubleValid()
        {
            // Arrange
            const double expectedResult = 730;

            using (ShimsContext.Create())
            {
                ShimConfigurationManager.AppSettingsGet = () =>
                                                          {
                                                              var values = new NameValueCollection();
                                                              values.Add(keyName, expectedResult.ToString(CultureInfo.InvariantCulture));

                                                              return values;
                                                          };

                // Act
                var actualResult = AppSettingsUtil.GetDouble(keyName);

                // Assert
                actualResult.Should().Be(expectedResult);
            }
        }

        [TestMethod]
        public void TestGetDoubleInvalid()
        {
            // Arrange
            using (ShimsContext.Create())
            {
                ShimConfigurationManager.AppSettingsGet = () =>
                                                          {
                                                              var values = new NameValueCollection();
                                                              values.Add(keyName, "bar");

                                                              return values;
                                                          };

                // Act
                Action act = () => AppSettingsUtil.GetDouble(keyName);

                // Assert
                act.ShouldThrow<ConfigurationErrorsException>();
            }
        }

        [TestMethod]
        public void TestGetDoubleWithDefault1()
        {
            // Arrange
            const double defaultValue = 666;
            const double expectedResult = 730;

            using (ShimsContext.Create())
            {
                ShimConfigurationManager.AppSettingsGet = () =>
                                                          {
                                                              var values = new NameValueCollection();
                                                              values.Add(keyName, expectedResult.ToString(CultureInfo.InvariantCulture));

                                                              return values;
                                                          };

                // Act
                var actualResult = AppSettingsUtil.GetDouble(keyName, defaultValue);

                // Assert
                actualResult.Should().Be(expectedResult);
            }
        }

        [TestMethod]
        public void TestGetDoubleWithDefault2()
        {
            // Arrange
            const double expectedResult = 666;

            using (ShimsContext.Create())
            {
                ShimConfigurationManager.AppSettingsGet = () =>
                                                          {
                                                              var values = new NameValueCollection();

                                                              return values;
                                                          };

                // Act
                var actualResult = AppSettingsUtil.GetDouble(keyName, expectedResult);

                // Assert
                actualResult.Should().Be(expectedResult);
            }
        }

        [TestMethod]
        public void TestGetDoubleWithoutDefault()
        {
            using (ShimsContext.Create())
            {
                // Arrange
                ShimConfigurationManager.AppSettingsGet = () =>
                                                          {
                                                              var values = new NameValueCollection();

                                                              return values;
                                                          };

                // Act
                Action act = () => AppSettingsUtil.GetDouble(keyName);

                // Assert
                act.ShouldThrow<ConfigurationErrorsException>();
            }
        }

        [TestMethod]
        public void TestGetIntValid()
        {
            // Arrange
            const int expectedResult = 730;

            using (ShimsContext.Create())
            {
                ShimConfigurationManager.AppSettingsGet = () =>
                                                          {
                                                              var values = new NameValueCollection();
                                                              values.Add(keyName, expectedResult.ToString(CultureInfo.InvariantCulture));

                                                              return values;
                                                          };

                // Act
                var actualResult = AppSettingsUtil.GetInt(keyName);

                // Assert
                actualResult.Should().Be(expectedResult);
            }
        }

        [TestMethod]
        public void TestGetIntInvalid()
        {
            // Arrange
            using (ShimsContext.Create())
            {
                ShimConfigurationManager.AppSettingsGet = () =>
                                                          {
                                                              var values = new NameValueCollection();
                                                              values.Add(keyName, "bar");

                                                              return values;
                                                          };

                // Act
                Action act = () => AppSettingsUtil.GetInt(keyName);

                // Assert
                act.ShouldThrow<ConfigurationErrorsException>();
            }
        }

        [TestMethod]
        public void TestGetIntWithDefault1()
        {
            // Arrange
            const int defaultValue = 666;
            const int expectedResult = 730;

            using (ShimsContext.Create())
            {
                ShimConfigurationManager.AppSettingsGet = () =>
                                                          {
                                                              var values = new NameValueCollection();
                                                              values.Add(keyName, expectedResult.ToString(CultureInfo.InvariantCulture));

                                                              return values;
                                                          };

                // Act
                var actualResult = AppSettingsUtil.GetInt(keyName, defaultValue);

                // Assert
                actualResult.Should().Be(expectedResult);
            }
        }

        [TestMethod]
        public void TestGetIntWithDefault2()
        {
            // Arrange
            const int expectedResult = 666;

            using (ShimsContext.Create())
            {
                ShimConfigurationManager.AppSettingsGet = () =>
                                                          {
                                                              var values = new NameValueCollection();

                                                              return values;
                                                          };

                // Act
                var actualResult = AppSettingsUtil.GetInt(keyName, expectedResult);

                // Assert
                actualResult.Should().Be(expectedResult);
            }
        }

        [TestMethod]
        public void TestGetIntWithoutDefault()
        {
            // Arrange
            using (ShimsContext.Create())
            {
                ShimConfigurationManager.AppSettingsGet = () =>
                                                          {
                                                              var values = new NameValueCollection();

                                                              return values;
                                                          };

                // Act
                Action act = () => AppSettingsUtil.GetInt(keyName);

                // Assert
                act.ShouldThrow<ConfigurationErrorsException>();
            }
        }

        [TestMethod]
        public void TestGetShortValid()
        {
            // Arrange
            const short expectedResult = 730;

            using (ShimsContext.Create())
            {
                ShimConfigurationManager.AppSettingsGet = () =>
                                                          {
                                                              var values = new NameValueCollection();
                                                              values.Add(keyName, expectedResult.ToString(CultureInfo.InvariantCulture));

                                                              return values;
                                                          };

                // Act
                var actualResult = AppSettingsUtil.GetShort(keyName);

                // Assert
                actualResult.Should().Be(expectedResult);
            }
        }

        [TestMethod]
        public void TestGetShortInvalid()
        {
            // Arrange
            using (ShimsContext.Create())
            {
                ShimConfigurationManager.AppSettingsGet = () =>
                                                          {
                                                              var values = new NameValueCollection();
                                                              values.Add(keyName, "bar");

                                                              return values;
                                                          };

                // Act
                Action act = () => AppSettingsUtil.GetShort(keyName);

                // Assert
                act.ShouldThrow<ConfigurationErrorsException>();
            }
        }

        [TestMethod]
        public void TestGetShortWithDefault1()
        {
            // Arrange
            const short defaultValue = 666;
            const short expectedResult = 730;

            using (ShimsContext.Create())
            {
                ShimConfigurationManager.AppSettingsGet = () =>
                                                          {
                                                              var values = new NameValueCollection();
                                                              values.Add(keyName, expectedResult.ToString(CultureInfo.InvariantCulture));

                                                              return values;
                                                          };

                // Act
                var actualResult = AppSettingsUtil.GetShort(keyName, defaultValue);

                // Assert
                actualResult.Should().Be(expectedResult);
            }
        }

        [TestMethod]
        public void TestGetShortWithDefault2()
        {
            // Arrange
            const short expectedResult = 666;

            using (ShimsContext.Create())
            {
                ShimConfigurationManager.AppSettingsGet = () =>
                                                          {
                                                              var values = new NameValueCollection();

                                                              return values;
                                                          };

                // Act
                var actualResult = AppSettingsUtil.GetShort(keyName, expectedResult);

                // Assert
                actualResult.Should().Be(expectedResult);
            }
        }

        [TestMethod]
        public void TestGetShortWithoutDefault()
        {
            // Arrange
            using (ShimsContext.Create())
            {
                ShimConfigurationManager.AppSettingsGet = () =>
                                                          {
                                                              var values = new NameValueCollection();

                                                              return values;
                                                          };

                // Act
                Action act = () => AppSettingsUtil.GetShort(keyName);

                // Assert
                act.ShouldThrow<ConfigurationErrorsException>();
            }
        }

        [TestMethod]
        public void TestGetBoolWithValidValue()
        {
            // Arrange
            const bool expectedResult = true;

            using (ShimsContext.Create())
            {
                ShimConfigurationManager.AppSettingsGet = () =>
                                                          {
                                                              var values = new NameValueCollection();
                                                              values.Add(keyName, expectedResult.ToString(CultureInfo.InvariantCulture));

                                                              return values;
                                                          };

                // Act
                var actualResult = AppSettingsUtil.GetBool(keyName);

                // Assert
                actualResult.Should().Be(expectedResult);
            }
        }

        [TestMethod]
        public void TestGetBoolWithInvalidValue()
        {
            // Arrange
            using (ShimsContext.Create())
            {
                ShimConfigurationManager.AppSettingsGet = () =>
                                                          {
                                                              var values = new NameValueCollection();
                                                              values.Add(keyName, "bar");

                                                              return values;
                                                          };

                // Act
                Action act = () => AppSettingsUtil.GetBool(keyName);

                // Assert
                act.ShouldThrow<ConfigurationErrorsException>();
            }
        }

        [TestMethod]
        public void TestGetBoolWithoutValue()
        {
            // Arrange
            using (ShimsContext.Create())
            {
                ShimConfigurationManager.AppSettingsGet = () =>
                                                          {
                                                              var values = new NameValueCollection();

                                                              return values;
                                                          };

                // Act
                Action act = () => AppSettingsUtil.GetBool(keyName);

                // Assert
                act.ShouldThrow<ConfigurationErrorsException>();
            }
        }

        [TestMethod]
        public void TestGetBoolDefaultWithValidValue()
        {
            // Arrange
            const bool defaultValue = false;
            const bool expectedResult = true;

            using (ShimsContext.Create())
            {
                ShimConfigurationManager.AppSettingsGet = () =>
                                                          {
                                                              var values = new NameValueCollection();
                                                              values.Add(keyName, expectedResult.ToString(CultureInfo.InvariantCulture));

                                                              return values;
                                                          };

                // Act
                var actualResult = AppSettingsUtil.GetBool(keyName, defaultValue);

                // Assert
                actualResult.Should().Be(expectedResult);
            }
        }

        [TestMethod]
        public void TestGetBoolDefaultWithInvalidValue()
        {
            // Arrange
            const bool defaultValue = false;
            const bool expectedResult = defaultValue;

            using (ShimsContext.Create())
            {
                ShimConfigurationManager.AppSettingsGet = () =>
                                                          {
                                                              var values = new NameValueCollection();
                                                              values.Add(keyName, "bar");

                                                              return values;
                                                          };

                // Act
                var actualResult = AppSettingsUtil.GetBool(keyName, defaultValue);

                // Assert
                actualResult.Should().Be(expectedResult);
            }
        }

        [TestMethod]
        public void TestGetBoolDefaultWithoutValue()
        {
            // Arrange
            const bool defaultValue = false;
            const bool expectedResult = defaultValue;

            using (ShimsContext.Create())
            {
                ShimConfigurationManager.AppSettingsGet = () =>
                                                          {
                                                              var values = new NameValueCollection();

                                                              return values;
                                                          };

                // Act
                var actualResult = AppSettingsUtil.GetBool(keyName, defaultValue);

                // Assert
                actualResult.Should().Be(expectedResult);
            }
        }

        [TestMethod]
        public void TestTryGetBoolWithValidValue()
        {
            // Arrange
            const bool expectedValue = true;
            const bool expectedReturnValue = true;
            bool actualValue;

            using (ShimsContext.Create())
            {
                ShimConfigurationManager.AppSettingsGet = () =>
                                                          {
                                                              var values = new NameValueCollection();
                                                              values.Add(keyName, expectedValue.ToString(CultureInfo.InvariantCulture));

                                                              return values;
                                                          };

                // Act
                var actualReturnValue = AppSettingsUtil.TryGetBool(keyName, out actualValue);

                // Assert
                actualReturnValue.Should().Be(expectedReturnValue);
                actualValue.Should().Be(expectedValue);
            }
        }

        [TestMethod]
        public void TestTryGetBoolWithInvalidValue()
        {
            // Arrange
            const bool expectedReturnValue = false;
            bool actualValue;

            using (ShimsContext.Create())
            {
                ShimConfigurationManager.AppSettingsGet = () =>
                                                          {
                                                              var values = new NameValueCollection();
                                                              values.Add(keyName, "bar");

                                                              return values;
                                                          };

                // Act
                var actualReturnValue = AppSettingsUtil.TryGetBool(keyName, out actualValue);

                // Assert
                actualReturnValue.Should().Be(expectedReturnValue);
            }
        }

        [TestMethod]
        public void TestTryGetBoolWithNoValue()
        {
            // Arrange
            const bool expectedReturnValue = false;
            bool actualValue;

            using (ShimsContext.Create())
            {
                ShimConfigurationManager.AppSettingsGet = () =>
                                                          {
                                                              var values = new NameValueCollection();

                                                              return values;
                                                          };

                // Act
                var actualReturnValue = AppSettingsUtil.TryGetBool(keyName, out actualValue);

                // Assert
                actualReturnValue.Should().Be(expectedReturnValue);
            }
        }

        [TestMethod]
        public void TestGetDaysWithValidValue()
        {
            // Arrange
            var expectedResult = new TimeSpan(730, 0, 0, 0);

            using (ShimsContext.Create())
            {
                ShimConfigurationManager.AppSettingsGet = () =>
                                                          {
                                                              var values = new NameValueCollection();
                                                              values.Add(keyName, expectedResult.TotalDays.ToString());

                                                              return values;
                                                          };

                // Act
                var actualResult = AppSettingsUtil.GetDays(keyName);

                // Assert
                actualResult.Should().Be(expectedResult);
            }
        }

        [TestMethod]
        public void TestGetDaysWithInvalidValue()
        {
            // Arrange
            using (ShimsContext.Create())
            {
                ShimConfigurationManager.AppSettingsGet = () =>
                                                          {
                                                              var values = new NameValueCollection();
                                                              values.Add(keyName, "bar");

                                                              return values;
                                                          };

                // Act
                Action act = () => AppSettingsUtil.GetDays(keyName);

                // Assert
                act.ShouldThrow<ConfigurationErrorsException>();
            }
        }

        [TestMethod]
        public void TestGetDaysWithoutValue()
        {
            // Arrange
            using (ShimsContext.Create())
            {
                ShimConfigurationManager.AppSettingsGet = () =>
                                                          {
                                                              var values = new NameValueCollection();

                                                              return values;
                                                          };

                // Act
                Action act = () => AppSettingsUtil.GetDays(keyName);

                // Assert
                act.ShouldThrow<ConfigurationErrorsException>();
            }
        }

        [TestMethod]
        public void TestGetDaysDefaultWithValidValue()
        {
            // Arrange
            var defaultValue = new TimeSpan(365, 0, 0, 0);
            var expectedResult = new TimeSpan(730, 0, 0, 0);

            using (ShimsContext.Create())
            {
                ShimConfigurationManager.AppSettingsGet = () =>
                                                          {
                                                              var values = new NameValueCollection();
                                                              values.Add(keyName, expectedResult.TotalDays.ToString());

                                                              return values;
                                                          };

                // Act
                var actualResult = AppSettingsUtil.GetDays(keyName, defaultValue.TotalDays);

                // Assert
                actualResult.Should().Be(expectedResult);
            }
        }

        [TestMethod]
        public void TestGetDaysDefaultWithInvalidValue()
        {
            // Arrange
            var defaultValue = new TimeSpan(365, 0, 0, 0);
            var expectedResult = defaultValue;

            using (ShimsContext.Create())
            {
                ShimConfigurationManager.AppSettingsGet = () =>
                                                          {
                                                              var values = new NameValueCollection();
                                                              values.Add(keyName, "bar");

                                                              return values;
                                                          };

                // Act
                var actualResult = AppSettingsUtil.GetDays(keyName, defaultValue.TotalDays);

                // Assert
                actualResult.Should().Be(expectedResult);
            }
        }

        [TestMethod]
        public void TestGetDaysDefaultWithoutValue()
        {
            // Arrange
            var defaultValue = new TimeSpan(365, 0, 0, 0);
            var expectedResult = defaultValue;

            using (ShimsContext.Create())
            {
                ShimConfigurationManager.AppSettingsGet = () =>
                                                          {
                                                              var values = new NameValueCollection();

                                                              return values;
                                                          };

                // Act
                var actualResult = AppSettingsUtil.GetDays(keyName, defaultValue.TotalDays);

                // Assert
                actualResult.Should().Be(expectedResult);
            }
        }

        [TestMethod]
        public void TestGetMinutesWithValidValue()
        {
            // Arrange
            var expectedResult = new TimeSpan(730, 0, 0, 0);

            using (ShimsContext.Create())
            {
                ShimConfigurationManager.AppSettingsGet = () =>
                                                          {
                                                              var values = new NameValueCollection();
                                                              values.Add(keyName, expectedResult.TotalMinutes.ToString());

                                                              return values;
                                                          };

                // Act
                var actualResult = AppSettingsUtil.GetMinutes(keyName);

                // Assert
                actualResult.Should().Be(expectedResult);
            }
        }

        [TestMethod]
        public void TestGetMinutesWithInvalidValue()
        {
            // Arrange
            using (ShimsContext.Create())
            {
                ShimConfigurationManager.AppSettingsGet = () =>
                                                          {
                                                              var values = new NameValueCollection();
                                                              values.Add(keyName, "bar");

                                                              return values;
                                                          };

                // Act
                Action act = () => AppSettingsUtil.GetMinutes(keyName);

                // Assert
                act.ShouldThrow<ConfigurationErrorsException>();
            }
        }

        [TestMethod]
        public void TestGetMinutesWithoutValue()
        {
            // Arrange
            using (ShimsContext.Create())
            {
                ShimConfigurationManager.AppSettingsGet = () =>
                                                          {
                                                              var values = new NameValueCollection();

                                                              return values;
                                                          };

                // Act
                Action act = () => AppSettingsUtil.GetMinutes(keyName);

                // Assert
                act.ShouldThrow<ConfigurationErrorsException>();
            }
        }

        [TestMethod]
        public void TestGetMinutesDefaultWithValidValue()
        {
            // Arrange
            var defaultValue = new TimeSpan(365, 0, 0, 0);
            var expectedResult = new TimeSpan(730, 0, 0, 0);

            using (ShimsContext.Create())
            {
                ShimConfigurationManager.AppSettingsGet = () =>
                                                          {
                                                              var values = new NameValueCollection();
                                                              values.Add(keyName, expectedResult.TotalMinutes.ToString());

                                                              return values;
                                                          };

                // Act
                var actualResult = AppSettingsUtil.GetMinutes(keyName, defaultValue.TotalMinutes);

                // Assert
                actualResult.Should().Be(expectedResult);
            }
        }

        [TestMethod]
        public void TestGetMinutesDefaultWithInvalidValue()
        {
            // Arrange
            var defaultValue = new TimeSpan(365, 0, 0, 0);
            var expectedResult = defaultValue;

            using (ShimsContext.Create())
            {
                ShimConfigurationManager.AppSettingsGet = () =>
                                                          {
                                                              var values = new NameValueCollection();
                                                              values.Add(keyName, "bar");

                                                              return values;
                                                          };

                // Act
                var actualResult = AppSettingsUtil.GetMinutes(keyName, defaultValue.TotalMinutes);

                // Assert
                actualResult.Should().Be(expectedResult);
            }
        }

        [TestMethod]
        public void TestGetMinutesDefaultWithoutValue()
        {
            // Arrange
            var defaultValue = new TimeSpan(365, 0, 0, 0);
            var expectedResult = defaultValue;

            using (ShimsContext.Create())
            {
                ShimConfigurationManager.AppSettingsGet = () =>
                                                          {
                                                              var values = new NameValueCollection();

                                                              return values;
                                                          };

                // Act
                var actualResult = AppSettingsUtil.GetMinutes(keyName, defaultValue.TotalMinutes);

                // Assert
                actualResult.Should().Be(expectedResult);
            }
        }

        [TestMethod]
        public void TestGetSecondsWithValidValue()
        {
            // Arrange
            var expectedResult = new TimeSpan(730, 0, 0, 0);

            using (ShimsContext.Create())
            {
                ShimConfigurationManager.AppSettingsGet = () =>
                                                          {
                                                              var values = new NameValueCollection();
                                                              values.Add(keyName, expectedResult.TotalSeconds.ToString());

                                                              return values;
                                                          };

                // Act
                var actualResult = AppSettingsUtil.GetSeconds(keyName);

                // Assert
                actualResult.Should().Be(expectedResult);
            }
        }

        [TestMethod]
        public void TestGetSecondsWithInvalidValue()
        {
            // Arrange
            using (ShimsContext.Create())
            {
                ShimConfigurationManager.AppSettingsGet = () =>
                                                          {
                                                              var values = new NameValueCollection();
                                                              values.Add(keyName, "bar");

                                                              return values;
                                                          };

                // Act
                Action act = () => AppSettingsUtil.GetSeconds(keyName);

                // Assert
                act.ShouldThrow<ConfigurationErrorsException>();
            }
        }

        [TestMethod]
        public void TestGetSecondsWithoutValue()
        {
            // Arrange
            using (ShimsContext.Create())
            {
                ShimConfigurationManager.AppSettingsGet = () =>
                                                          {
                                                              var values = new NameValueCollection();

                                                              return values;
                                                          };

                // Act
                Action act = () => AppSettingsUtil.GetSeconds(keyName);

                // Assert
                act.ShouldThrow<ConfigurationErrorsException>();
            }
        }

        [TestMethod]
        public void TestGetSecondsDefaultWithValidValue()
        {
            // Arrange
            var defaultValue = new TimeSpan(365, 0, 0, 0);
            var expectedResult = new TimeSpan(730, 0, 0, 0);

            using (ShimsContext.Create())
            {
                ShimConfigurationManager.AppSettingsGet = () =>
                                                          {
                                                              var values = new NameValueCollection();
                                                              values.Add(keyName, expectedResult.TotalSeconds.ToString());

                                                              return values;
                                                          };

                // Act
                var actualResult = AppSettingsUtil.GetSeconds(keyName, defaultValue.TotalSeconds);

                // Assert
                actualResult.Should().Be(expectedResult);
            }
        }

        [TestMethod]
        public void TestGetSecondsDefaultWithInvalidValue()
        {
            // Arrange
            var defaultValue = new TimeSpan(365, 0, 0, 0);
            var expectedResult = defaultValue;

            using (ShimsContext.Create())
            {
                ShimConfigurationManager.AppSettingsGet = () =>
                                                          {
                                                              var values = new NameValueCollection();
                                                              values.Add(keyName, "bar");

                                                              return values;
                                                          };

                // Act
                var actualResult = AppSettingsUtil.GetSeconds(keyName, defaultValue.TotalSeconds);

                // Assert
                actualResult.Should().Be(expectedResult);
            }
        }

        [TestMethod]
        public void TestGetSecondsDefaultWithoutValue()
        {
            // Arrange
            var defaultValue = new TimeSpan(365, 0, 0, 0);
            var expectedResult = defaultValue;

            using (ShimsContext.Create())
            {
                ShimConfigurationManager.AppSettingsGet = () =>
                                                          {
                                                              var values = new NameValueCollection();

                                                              return values;
                                                          };

                // Act
                var actualResult = AppSettingsUtil.GetSeconds(keyName, defaultValue.TotalSeconds);

                // Assert
                actualResult.Should().Be(expectedResult);
            }
        }

        [TestMethod]
        public void TestGetMillisecondsWithValidValue()
        {
            // Arrange
            var expectedResult = new TimeSpan(730, 0, 0, 0);

            using (ShimsContext.Create())
            {
                ShimConfigurationManager.AppSettingsGet = () =>
                                                          {
                                                              var values = new NameValueCollection();
                                                              values.Add(keyName, expectedResult.TotalMilliseconds.ToString());

                                                              return values;
                                                          };

                // Act
                var actualResult = AppSettingsUtil.GetMilliseconds(keyName);

                // Assert
                actualResult.Should().Be(expectedResult);
            }
        }

        [TestMethod]
        public void TestGetMillisecondsWithInvalidValue()
        {
            // Arrange
            using (ShimsContext.Create())
            {
                ShimConfigurationManager.AppSettingsGet = () =>
                                                          {
                                                              var values = new NameValueCollection();
                                                              values.Add(keyName, "bar");

                                                              return values;
                                                          };

                // Act
                Action act = () => AppSettingsUtil.GetMilliseconds(keyName);

                // Assert
                act.ShouldThrow<ConfigurationErrorsException>();
            }
        }

        [TestMethod]
        public void TestGetMillisecondsWithoutValue()
        {
            // Arrange
            using (ShimsContext.Create())
            {
                ShimConfigurationManager.AppSettingsGet = () =>
                                                          {
                                                              var values = new NameValueCollection();

                                                              return values;
                                                          };

                // Act
                Action act = () => AppSettingsUtil.GetMilliseconds(keyName);

                // Assert
                act.ShouldThrow<ConfigurationErrorsException>();
            }
        }

        [TestMethod]
        public void TestGetMillisecondsDefaultWithValidValue()
        {
            // Arrange
            var defaultValue = new TimeSpan(365, 0, 0, 0);
            var expectedResult = new TimeSpan(730, 0, 0, 0);

            using (ShimsContext.Create())
            {
                ShimConfigurationManager.AppSettingsGet = () =>
                                                          {
                                                              var values = new NameValueCollection();
                                                              values.Add(keyName, expectedResult.TotalMilliseconds.ToString());

                                                              return values;
                                                          };

                // Act
                var actualResult = AppSettingsUtil.GetMilliseconds(keyName, defaultValue.TotalMilliseconds);

                // Assert
                actualResult.Should().Be(expectedResult);
            }
        }

        [TestMethod]
        public void TestGetMillisecondsDefaultWithInvalidValue()
        {
            // Arrange
            var defaultValue = new TimeSpan(365, 0, 0, 0);
            var expectedResult = defaultValue;

            using (ShimsContext.Create())
            {
                ShimConfigurationManager.AppSettingsGet = () =>
                                                          {
                                                              var values = new NameValueCollection();
                                                              values.Add(keyName, "bar");

                                                              return values;
                                                          };

                // Act
                var actualResult = AppSettingsUtil.GetMilliseconds(keyName, defaultValue.TotalMilliseconds);

                // Assert
                actualResult.Should().Be(expectedResult);
            }
        }

        [TestMethod]
        public void TestGetMillisecondsDefaultWithoutValue()
        {
            // Arrange
            var defaultValue = new TimeSpan(365, 0, 0, 0);
            var expectedResult = defaultValue;

            using (ShimsContext.Create())
            {
                ShimConfigurationManager.AppSettingsGet = () =>
                                                          {
                                                              var values = new NameValueCollection();

                                                              return values;
                                                          };

                // Act
                var actualResult = AppSettingsUtil.GetMilliseconds(keyName, defaultValue.TotalMilliseconds);

                // Assert
                actualResult.Should().Be(expectedResult);
            }
        }

        [TestMethod]
        public void TestGetConnectionStringWithValue()
        {
            // Arrange
            var expectedResult = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=bar";

            using (ShimsContext.Create())
            {
                ShimConfigurationManager.ConnectionStringsGet = () =>
                                                                {
                                                                    var values = new ConnectionStringSettingsCollection();
                                                                    values.Add(new ConnectionStringSettings(keyName, expectedResult));

                                                                    return values;
                                                                };

                // Act
                var actualResult = AppSettingsUtil.GetConnectionString(keyName);

                // Assert
                actualResult.Should().Be(expectedResult);
            }
        }

        [TestMethod]
        public void TestGetConnectionStringWithoutValue()
        {
            // Arrange
            using (ShimsContext.Create())
            {
                ShimConfigurationManager.ConnectionStringsGet = () =>
                                                                {
                                                                    var values = new ConnectionStringSettingsCollection();

                                                                    return values;
                                                                };

                // Act
                Action act = () => AppSettingsUtil.GetConnectionString(keyName);

                // Assert
                act.ShouldThrow<ConfigurationErrorsException>();
            }
        }

        [TestMethod]
        public void TestConnectionStringExistsWithValue()
        {
            // Arrange
            var connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=bar";
            var expectedResult = true;

            using (ShimsContext.Create())
            {
                ShimConfigurationManager.ConnectionStringsGet = () =>
                                                                {
                                                                    var values = new ConnectionStringSettingsCollection();
                                                                    values.Add(new ConnectionStringSettings(keyName, connectionString));

                                                                    return values;
                                                                };

                // Act
                var actualResult = AppSettingsUtil.ConnectionStringExists(keyName);

                // Assert
                actualResult.Should().Be(expectedResult);
            }
        }

        [TestMethod]
        public void TestConnectionStringExistsWithoutValue()
        {
            // Arrange
            var expectedResult = false;

            using (ShimsContext.Create())
            {
                ShimConfigurationManager.ConnectionStringsGet = () =>
                                                                {
                                                                    var values = new ConnectionStringSettingsCollection();

                                                                    return values;
                                                                };

                // Act
                var actualResult = AppSettingsUtil.ConnectionStringExists(keyName);

                // Assert
                actualResult.Should().Be(expectedResult);
            }
        }

        #region Tests for GetUri

        [TestMethod]
        public void TestGetUri()
        {
            // Arrange
            const string expectedResult = "https://bar/";

            using (ShimsContext.Create())
            {
                ShimConfigurationManager.AppSettingsGet = () =>
                                                          {
                                                              var values = new NameValueCollection();
                                                              values.Add(keyName, expectedResult);

                                                              return values;
                                                          };
                // Act
                var actualResult = AppSettingsUtil.GetUri(keyName);

                // Assert
                actualResult.Should().Be(new Uri(expectedResult));
            }
        }

        [TestMethod]
        public void TestGetUriWithDefault1()
        {
            // Arrange
            const string defaultValue = "https://default/";
            const string expectedResult = "https://bar/";

            using (ShimsContext.Create())
            {
                ShimConfigurationManager.AppSettingsGet = () =>
                                                          {
                                                              var values = new NameValueCollection();
                                                              values.Add(keyName, expectedResult);

                                                              return values;
                                                          };
                // Act
                var actualResult = AppSettingsUtil.GetUri(keyName, defaultValue);

                // Assert
                actualResult.Should().Be(new Uri(expectedResult));
            }
        }

        [TestMethod]
        public void TestGetUriWithDefault2()
        {
            // Arrange
            const string expectedResult = "https://default/";

            using (ShimsContext.Create())
            {
                ShimConfigurationManager.AppSettingsGet = () =>
                                                          {
                                                              var values = new NameValueCollection();

                                                              return values;
                                                          };
                // Act
                var actualResult = AppSettingsUtil.GetUri(keyName, expectedResult);

                // Assert
                actualResult.Should().Be(new Uri(expectedResult));
            }
        }

        [TestMethod]
        public void TestGetUriWithoutDefault()
        {
            // Arrange
            using (ShimsContext.Create())
            {
                ShimConfigurationManager.AppSettingsGet = () =>
                                                          {
                                                              var values = new NameValueCollection();

                                                              return values;
                                                          };

                // Act
                Action act = () => AppSettingsUtil.GetUri(keyName);

                // Assert
                act.ShouldThrow<ConfigurationErrorsException>();
            }
        }

        #endregion

        #region Additional test attributes

        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //

        #endregion
    }
}