﻿using System;
using MRuby.Net.Native;
using Xunit;

namespace MRuby.Net.Tests.Native
{
    public unsafe class MrbTest
    {
        [Fact]
        public void mrb_close_CanCloseAnEnvironment()
        {
            var mrb = MrbMethods.mrb_open();
            MrbMethods.mrb_close(mrb);
        }

        [Fact]
        public void mrb_load_string_CanRunSomeCodeAndGetAFixnumBack()
        {
            var mrb = MrbMethods.mrb_open();

            var value = MrbMethods.mrb_load_string(mrb, "10 + 20");
            Assert.Equal(MrbValueType.Fixnum, value.ValueType);
            Assert.Equal(30U, value.IntegerValue);

            MrbMethods.mrb_close(mrb);
        }

        [Fact]
        public void mrb_load_stirng_CanRunSomeCodeAndGetNilBack()
        {
            var mrb = MrbMethods.mrb_open();

            var value = MrbMethods.mrb_load_string(mrb, "nil");
            Assert.True(value.IsNil);

            MrbMethods.mrb_close(mrb);
        }

        [Fact]
        public void mrb_load_string_CanRunSomeCodeAndGetFalseBack()
        {
            var mrb = MrbMethods.mrb_open();

            var value = MrbMethods.mrb_load_string(mrb, "false");
            Assert.True(value.IsFalse);

            MrbMethods.mrb_close(mrb);
        }

        [Fact]
        public void mrb_load_string_RaisesAnExceptionForInvalidCode()
        {
            var mrb = MrbMethods.mrb_open();

            Assert.Throws<Exception>(() => MrbMethods.mrb_load_string(mrb, "this is just some junk (not valid Ruby code)"));

            MrbMethods.mrb_close(mrb);
        }
    }
}
