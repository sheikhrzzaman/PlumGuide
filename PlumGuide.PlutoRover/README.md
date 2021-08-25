#Introduction
This function app will accept valid instructions to move the rover.

#APIs
local- http://localhost:7071/api/v1/plutorover/move
dev - http://dev-server/api/v1/plutorover/move
test - http://test-server/api/v1/plutorover/move
prod - http://prod-server/api/v1/plutorover/move

httpMethod = POST, body = FFLRFF (example)

#Validations
Fluent validator is used to validate input instructions. An approprite message is return for an invalid instructions.

# Code structures
Solution name - PlumGuide.PlutoRover, it has two projets
 1. scr: PlumGudide.PlutoRover
   - Folders: 
       a.  Function- function app file- validate input instruction and process the request if valid
       b.  Models - model file
       c.  Processors- this is wraper service to process instructions.
                     - Get current rover position
                     - Factory pattern is used to move the rover
                     - Move Validation service to validate the move
                     - if move is valid, it gets stored as current position
                     - if the move is invalid, it does not store that move and stay at the same position and ignore subsequet instructions

       d. Services
          i. PlutoBoundaryService - return pluto boundaries
          ii. PlutoObstableLocationService - return obstacles positions
          iii. RoverMoveBackwardService - move the rover backward
          iv. RoverMoveForwardService - move the river forward
          v. RoverMoveLeftService - move the rover left
          vi. RoverMoveRightService - move the rover right
          vii. RoverMoveServiceFactory - return approprite rover move service depending on the instruction
          viii. RoverMoveValidationService - validate rover next move
          ix. RoverPositionService - store and return rover current position
          
       f. Validators
          i. InstructionValidator - it uses fluentvalidation to validate instruction

       e. Constants- declared a few constants that are being using used more than once
       g. Starup- this file is used for dependency injection

2. test-PlumGuide.PlutoRover.Tests - This is a MS Test project to unit the services and other objects
   - The folder structures are the same as the project

3.Solution Items
   - it has got styecop and ruleset file to follow the same coding style through out the project.
4. Function needs to be secure using Azure AD