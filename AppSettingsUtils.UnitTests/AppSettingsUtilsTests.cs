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
        /// <summary>
        ///     Gets or sets the test context which provides
        ///     information about and functionality for the current test run.
        /// </summary>
        public TestContext TestContext { get; set; }

        [TestMethod]
        public void TestGetString()
        {
            const string key = "foo";
            const string expectedResult = "bar";

            // Arrange
            using (ShimsContext.Create())
            {
                ShimConfigurationManager.AppSettingsGet = () =>
                {
                    var values = new NameValueCollection();
                    values.Add(key, expectedResult);

                    return values;
                };
                // Act
                var actualResult = AppSettingsUtil.GetString(key);

                // Assert
                actualResult.Should().Be(expectedResult);
            }
        }

        [TestMethod]
        public void TestGetStringWithDefault1()
        {
            const string keyName = "foo";
            const string defaultValue = "default";
            const string expectedResult = "bar";

            // Arrange
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
            const string expectedResult = "default";

            // Arrange
            using (ShimsContext.Create())
            {
                ShimConfigurationManager.AppSettingsGet = () =>
                {
                    var values = new NameValueCollection();

                    return values;
                };
                // Act
                var actualResult = AppSettingsUtil.GetString("foo", expectedResult);

                // Assert
                actualResult.Should().Be(expectedResult);
            }
        }

        [TestMethod]
        public void TestGetStringWithoutDefault()
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
                Action act = () => AppSettingsUtil.GetString("foo");

                // Assert
                act.ShouldThrow<ConfigurationErrorsException>();
            }
        }

        [TestMethod]
        public void TestGetDoubleValid()
        {
            const string keyName = "foo";
            const double expectedResult = 730;

            // Arrange
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
            const string keyName = "foo";

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
            const string keyName = "foo";
            const double defaultValue = 666;
            const double expectedResult = 730;

            // Arrange
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
            const double expectedResult = 666;

            // Arrange
            using (ShimsContext.Create())
            {
                ShimConfigurationManager.AppSettingsGet = () =>
                {
                    var values = new NameValueCollection();

                    return values;
                };

                // Act
                var actualResult = AppSettingsUtil.GetDouble("foo", expectedResult);

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
                Action act = () => AppSettingsUtil.GetDouble("foo");

                // Assert
                act.ShouldThrow<ConfigurationErrorsException>();
            }
        }

        [TestMethod]
        public void TestGetIntValid()
        {
            const string keyName = "foo";
            const int expectedResult = 730;

            // Arrange
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
            const string keyName = "foo";

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
            const string keyName = "foo";
            const int defaultValue = 666;
            const int expectedResult = 730;

            // Arrange
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
            const int expectedResult = 666;

            // Arrange
            using (ShimsContext.Create())
            {
                ShimConfigurationManager.AppSettingsGet = () =>
                {
                    var values = new NameValueCollection();

                    return values;
                };

                // Act
                var actualResult = AppSettingsUtil.GetInt("foo", expectedResult);

                // Assert
                actualResult.Should().Be(expectedResult);
            }
        }

        [TestMethod]
        public void TestGetIntWithoutDefault()
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
                Action act = () => AppSettingsUtil.GetInt("foo");

                // Assert
                act.ShouldThrow<ConfigurationErrorsException>();
            }
        }

        [TestMethod]
        public void TestGetShortValid()
        {
            const string keyName = "foo";
            const short expectedResult = 730;

            // Arrange
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
            const string keyName = "foo";

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
            const string keyName = "foo";
            const short defaultValue = 666;
            const short expectedResult = 730;

            // Arrange
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
            const short expectedResult = 666;

            // Arrange
            using (ShimsContext.Create())
            {
                ShimConfigurationManager.AppSettingsGet = () =>
                {
                    var values = new NameValueCollection();

                    return values;
                };

                // Act
                var actualResult = AppSettingsUtil.GetShort("foo", expectedResult);

                // Assert
                actualResult.Should().Be(expectedResult);
            }
        }

        [TestMethod]
        public void TestGetShortWithoutDefault()
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
                Action act = () => AppSettingsUtil.GetShort("foo");

                // Assert
                act.ShouldThrow<ConfigurationErrorsException>();
            }
        }

        [TestMethod]
        public void TestGetBoolWithValidValue()
        {
            const string keyName = "foo";
            const bool expectedResult = true;

            // Arrange
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
            const string keyName = "foo";

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
            const string keyName = "foo";

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
            const string keyName = "foo";
            const bool defaultValue = false;
            const bool expectedResult = true;

            // Arrange
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
            const string keyName = "foo";
            const bool defaultValue = false;
            const bool expectedResult = defaultValue;

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
                var actualResult = AppSettingsUtil.GetBool(keyName, defaultValue);

                // Assert
                actualResult.Should().Be(expectedResult);
            }
        }

        [TestMethod]
        public void TestGetBoolDefaultWithoutValue()
        {
            const string keyName = "foo";
            const bool defaultValue = false;
            const bool expectedResult = defaultValue;

            // Arrange
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
            const string keyName = "foo";
            const bool expectedValue = true;
            const bool expectedReturnValue = true;
            bool actualValue;


            // Arrange
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
            const string keyName = "foo";
            const bool expectedReturnValue = false;
            bool actualValue;


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
                var actualReturnValue = AppSettingsUtil.TryGetBool(keyName, out actualValue);

                // Assert
                actualReturnValue.Should().Be(expectedReturnValue);
            }
        }

        [TestMethod]
        public void TestTryGetBoolWithNoValue()
        {
            const string keyName = "foo";
            const bool expectedReturnValue = false;
            bool actualValue;


            // Arrange
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
        public void TestGetMinutesWithValidValue()
        {
            const string keyName = "foo";
            var expectedResult = new TimeSpan(730, 0, 0, 0);

            // Arrange
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
            const string keyName = "foo";

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
            const string keyName = "foo";

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
            const string keyName = "foo";
            var defaultValue = new TimeSpan(365, 0, 0, 0);
            var expectedResult = new TimeSpan(730, 0, 0, 0);

            // Arrange
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
            const string keyName = "foo";
            var defaultValue = new TimeSpan(365, 0, 0, 0);
            var expectedResult = defaultValue;

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
                var actualResult = AppSettingsUtil.GetMinutes(keyName, defaultValue.TotalMinutes);

                // Assert
                actualResult.Should().Be(expectedResult);
            }
        }

        [TestMethod]
        public void TestGetMinutesDefaultWithoutValue()
        {
            const string keyName = "foo";
            var defaultValue = new TimeSpan(365, 0, 0, 0);
            var expectedResult = defaultValue;

            // Arrange
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
            const string keyName = "foo";
            var expectedResult = new TimeSpan(730, 0, 0, 0);

            // Arrange
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
            const string keyName = "foo";

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
            const string keyName = "foo";

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
            const string keyName = "foo";
            var defaultValue = new TimeSpan(365, 0, 0, 0);
            var expectedResult = new TimeSpan(730, 0, 0, 0);

            // Arrange
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
            const string keyName = "foo";
            var defaultValue = new TimeSpan(365, 0, 0, 0);
            var expectedResult = defaultValue;

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
                var actualResult = AppSettingsUtil.GetSeconds(keyName, defaultValue.TotalSeconds);

                // Assert
                actualResult.Should().Be(expectedResult);
            }
        }

        [TestMethod]
        public void TestGetSecondsDefaultWithoutValue()
        {
            const string keyName = "foo";
            var defaultValue = new TimeSpan(365, 0, 0, 0);
            var expectedResult = defaultValue;

            // Arrange
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
            const string keyName = "foo";
            var expectedResult = new TimeSpan(730, 0, 0, 0);

            // Arrange
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
            const string keyName = "foo";

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
            const string keyName = "foo";

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
            const string keyName = "foo";
            var defaultValue = new TimeSpan(365, 0, 0, 0);
            var expectedResult = new TimeSpan(730, 0, 0, 0);

            // Arrange
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
            const string keyName = "foo";
            var defaultValue = new TimeSpan(365, 0, 0, 0);
            var expectedResult = defaultValue;

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
                var actualResult = AppSettingsUtil.GetMilliseconds(keyName, defaultValue.TotalMilliseconds);

                // Assert
                actualResult.Should().Be(expectedResult);
            }
        }

        [TestMethod]
        public void TestGetMillisecondsDefaultWithoutValue()
        {
            const string keyName = "foo";
            var defaultValue = new TimeSpan(365, 0, 0, 0);
            var expectedResult = defaultValue;

            // Arrange
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
            const string keyName = "foo";
            var expectedResult = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=bar";

            // Arrange
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
            const string keyName = "foo";

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
            const string keyName = "foo";
            var connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=bar";
            var expectedResult = true;

            // Arrange
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
            const string keyName = "foo";
            var expectedResult = false;

            // Arrange
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