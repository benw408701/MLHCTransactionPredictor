//
// Encog(tm) Core v3.2 - .Net Version
// http://www.heatonresearch.com/encog/
//
// Copyright 2008-2014 Heaton Research, Inc.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//  http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//   
// For more information on Heaton Research copyrights, licenses 
// and trademarks visit:
// http://www.heatonresearch.com/copyright
//
namespace Encog.ML
{
    /// <summary>
    /// This is a convenience interface that combines MLInput and MLOutput.  
    /// Together these define a MLMethod that both accepts input and 
    /// produces output.
    /// Input and output are defined as a simple array of double values.  
    /// Many machine learning methods, such as neural networks and 
    /// support vector machines handle input and output in this way, 
    /// and thus implement this interface.  Others, such as clustering, 
    /// do not.
    /// </summary>
    ///
    public interface IMLInputOutput : IMLInput, IMLOutput
    {
    }
}
