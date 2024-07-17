cmake_minimum_required (VERSION 3.2.2)

set(CMAKE_CXX_STANDARD 14)

enable_testing()

include(ExternalProject)
project(FASTER)

# The set of additional options that we can pass into cmake. We currently support
# a flag `USE_BLOBS` that will link in azure's blob store library so that FASTER
# can be used with a blob device for the hybrid log.
OPTION(USE_BLOBS "Extend FASTER's hybrid log to blob store" OFF)
OPTION(USE_URING "Enable io_uring based IO handler" OFF)

set(CMAKE_CXX_FLAGS "${CMAKE_CXX_FLAGS} -std=c++14")

set(CMAKE_CXX_FLAGS_RELEASE "${CMAKE_CXX_FLAGS_RELEASE} -O3 -g")

include_directories(${CMAKE_SOURCE_DIR}/src)

# Set the directory targets when build in libs and binaries
set(CMAKE_ARCHIVE_OUTPUT_DIRECTORY ${CMAKE_BINARY_DIR})
set(CMAKE_LIBRARY_OUTPUT_DIRECTORY ${CMAKE_BINARY_DIR})
set(CMAKE_RUNTIME_OUTPUT_DIRECTORY ${CMAKE_BINARY_DIR})

set (FASTER_LINK_LIBS
  faster
)

add_subdirectory(src)
