using Moq;  
using System;  
using System.Collections.Generic;  
using Xunit;  
  
namespace SpaceBattle.Lib.Tests  
{  
    public class SimpleMacroCommandTests  
    {  
        [Fact]  
        public void Execute_CallsForEachCommand()  
        {  
            //  
            var command1 = new Mock<ICommand>();  
            var command2 = new Mock<ICommand>();  
            var commands = new List<ICommand> { command1.Object, command2.Object };  
            var macroCommand = new SimpleMacroCommand(commands);  
  
            //   
            macroCommand.Execute();  
  
            //  
            command1.Verify(c => c.Execute(), Times.Once);  
            command2.Verify(c => c.Execute(), Times.Once);  
        }  
  
        [Fact]  
        public void Execute_DoesNothingForEmptyList()  
        {  
            //   
            var commands = new List<ICommand>();  
            var macroCommand = new SimpleMacroCommand(commands);  
  
            //  
            macroCommand.Execute();  
  
              
        }  
  
        [Fact]  
        public void Constructor_ThrowsArgumentNullExceptionForNullCommands()  
        {  
            // Arrange & Act & Assert  
            Assert.Throws<ArgumentNullException>(() => new SimpleMacroCommand(null));  
        }  
  
        [Fact]  
        public void Execute_ThrowsArgumentNullExceptionForNullCommandInList()  
        {  
            //  
            var command1 = new Mock<ICommand>();  
            var commands = new List<ICommand> { command1.Object, null };  
            var macroCommand = new SimpleMacroCommand(commands);  
  
            //  
            Assert.Throws<ArgumentNullException>(() => macroCommand.Execute());  
        }  
  
        [Fact]  
        public void Execute_ThrowsExceptionForFailedCommand()  
        {  
            // 
            var command1 = new Mock<ICommand>();  
            var command2 = new Mock<ICommand>();  
            command2.Setup(c => c.Execute()).Throws<Exception>();  
            var commands = new List<ICommand> { command1.Object, command2.Object };  
            var macroCommand = new SimpleMacroCommand(commands);  
  
            //  
            Assert.Throws<Exception>(() => macroCommand.Execute());  
            command1.Verify(c => c.Execute(), Times.Once);  
        }  
    }  
} 